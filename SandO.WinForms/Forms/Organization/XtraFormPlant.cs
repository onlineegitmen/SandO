using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SandO.Bll.Managers;
using SandO.Entities.AppClasses;
using SandO.Entities.AppClasses.Organization;
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.MainForm;
using SandO.Entities.Db;
using SandO.Entities.Enums;

namespace SandO.WinForms.Forms.Organization
{
    /// <summary>
    /// Üretim yeri formu
    /// </summary>
    public partial class XtraFormPlant : XtraForm
    {
        public string FormObjectDesc => "Üreti Yeri";
        public Plant Plant { get; private set; }
        public int ObjId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }
        public List<CompanyForSelection> CompaniesForSelection { get; set; }

        public XtraFormPlant()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormPlant(int objId, FormOpenOption formOpenOption)
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
            barButtonItemSave.Visibility = FormOpenOption.IsReadOnly() ? BarItemVisibility.Never : BarItemVisibility.Always;
            barButtonItemViewLogs.Visibility = FormOpenOption == FormOpenOption.Create ? BarItemVisibility.Never : BarItemVisibility.Always;

            barButtonItemCancel.Caption = FormOpenOption.IsReadOnly() ? "Kapat" : "İptal";
        }

        private bool SetValues()
        {
            if (Plant == null || Plant.Id == 0)
            {
                return false;
            }

            Text = FormOpenOption switch
            {
                FormOpenOption.View => $"{FormObjectDesc} - {Plant.Name}",
                FormOpenOption.Update => $"{FormObjectDesc} - {Plant.Name}",
                FormOpenOption.Create => $"Yeni {FormObjectDesc}",
                _ => Text
            };

            // Set values to controls
            textEditCode.Text = Plant.Code;
            textEditName.Text = Plant.Name;
            comboBoxEditCompanies.SelectedItem = CompaniesForSelection.FirstOrDefault(x => x.Id == Plant.CompanyId);

            return true;
        }

        private bool GetMasterDatas()
        {
            CompanyManager companyManager = new CompanyManager();
            QueryResult<List<CompanyForSelection>> queryResult = companyManager.GetCompaniesForSelection();
            if (queryResult.Result)
            {
                CompaniesForSelection = queryResult.ResultObject;
            }

            comboBoxEditCompanies.Properties.Items.AddRange(CompaniesForSelection);

            return true;
        }

        private bool GetObject()
        {
            if (ObjId == 0)
            {
                Plant = new Plant();
                return false;
            }

            CompanyManager companyManager = new CompanyManager();
            QueryResult<Plant> queryResult = companyManager.GetPlant(ObjId);
            if (queryResult.Result)
            {
                Plant = queryResult.ResultObject;
            }
            else
            {
                ribbonControl.SetMessage(queryResult.Message, MessageType.Error);
            }

            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Plant.Code = textEditCode.Text;
            Plant.Name = textEditName.Text;
            Plant.CompanyId = ((CompanyForSelection)comboBoxEditCompanies.SelectedItem)?.Id ?? 0;
            WaitFormMain.ShowWaitForm(description: "Kaydediliyor");
            CompanyManager companyManager = new CompanyManager();
            switch (FormOpenOption)
            {
                case FormOpenOption.Create:
                    ProgressResult = companyManager.AddPlant(Plant);
                    break;
                case FormOpenOption.Update:
                    ProgressResult = companyManager.UpdatePlant(Plant);
                    break;
                case FormOpenOption.View:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            WaitFormMain.CloseWaitForm();

            if (ProgressResult.Result)
            {
                Close();
            }
            else
            {
                ProgressResult.Show();
            }
        }

        private void barButtonItemCancel_ItemClick(object sender, ItemClickEventArgs e)
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

        private void barButtonItemViewLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(Plant.Guid, typeof(Plant));
            xtraFormRecordLogs.ShowDialog();
        }
    }
}