using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SandO.Bll.Managers;
using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.MainForm;
using SandO.WinForms.Templates;

namespace SandO.WinForms.Forms.Organization
{
    public partial class XtraFormCompany : XtraForm
    {
        public Company Company { get; private set; }
        public int ObjId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }

        public XtraFormCompany()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormCompany(int objId, FormOpenOption formOpenOption)
        {
            InitializeComponent();
            ObjId = objId;
            FormOpenOption = formOpenOption;
            ProgressResult = new ProgressResult(false);
        }

        private void XtraFormTemp_Load(object sender, EventArgs e)
        {
            XtraFormMain xtraFormMain = ActiveForm as XtraFormMain;
            IconOptions.Icon = xtraFormMain?.IconOptions.Icon;

            GetMasterDatas();
            GetObject();
            SetValues();


            ribbonControl.SetRibbonStyle();
            this.SetEditableStatus(FormOpenOption.IsReadOnly());
            SetControlsVisible();

            WaitFormMain.CloseWaitForm();
        }

        private void SetControlsVisible()
        {
            barButtonItemSave.Visibility = FormOpenOption.IsReadOnly() ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItemViewLogs.Visibility = FormOpenOption != FormOpenOption.Create ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            barButtonItemCancel.Caption = FormOpenOption.IsReadOnly() ? "Kapat" : "İptal";
        }

        private bool SetValues()
        {
            if (Company == null || Company.Id == 0)
            {
                Text = "Yeni Şirket";
                return false;
            }

            switch (FormOpenOption)
            {
                case FormOpenOption.View:
                    Text = $"Şirket - {Company.Name}";
                    break;
                case FormOpenOption.Update:
                    Text = $"Şirket Düzenle - {Company.Name}";
                    break;
                case FormOpenOption.Create:
                    Text = "Yeni Şirket";
                    break;
            }

            textEditCompanyCode.Text = Company.Code;
            textEditCompanyName.Text = Company.Name;
            textEditTaxOffice.Text = Company.TaxOffice;
            textEditTaxNumber.Text = Company.TaxNumber;
            textEditTradeRegistryNumber.Text = Company.TradeRegistryNumber;


            return true;
        }

        private bool GetMasterDatas()
        {
            return true;
        }

        private bool GetObject()
        {
            if (ObjId == 0)
            {
                Company = new Company();
                return false;
            }

            CompanyManager companyManager = new CompanyManager();
            QueryResult<Company> queryResult = companyManager.GetCompany(ObjId);
            if (queryResult.Result)
            {
                Company = queryResult.ResultObject;
                return true;
            }

            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Company.Code = textEditCompanyCode.Text;
            Company.Name = textEditCompanyName.Text;
            Company.TaxOffice = textEditTaxOffice.Text;
            Company.TaxNumber = textEditTaxNumber.Text;
            Company.TradeRegistryNumber = textEditTradeRegistryNumber.Text;

            CompanyManager companyManager = new CompanyManager();
            WaitFormMain.ShowWaitForm();
            if (FormOpenOption == FormOpenOption.Create)
            {
                ProgressResult = companyManager.AddCompany(Company);
            }
            else if (FormOpenOption == FormOpenOption.Update)
            {
                ProgressResult = companyManager.UpdateCompany(Company);
            }
            WaitFormMain.CloseWaitForm();

            if (ProgressResult.Result)
            {
                Close();
            }
        }

        private void barButtonItemCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FormOpenOption != FormOpenOption.View && XtraMessageBox.Show("Kaydedilmeyen değişiklikler kaybolacak. Devam etmek istiyor musunuz?", "İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                Close();
            }
        }

        private void XtraFormTemp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                barButtonItemCancel_ItemClick(null, null);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                barButtonItemSave_ItemClick(null, null);
            }
        }

        private void barButtonItemViewLogs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(Company.Guid, typeof(Company));
            xtraFormRecordLogs.ShowDialog();
        }
    }
}