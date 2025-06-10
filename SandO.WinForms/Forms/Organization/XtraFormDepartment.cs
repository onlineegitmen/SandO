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
using SandO.Bll.Managers;
using SandO.Entities.AppClasses;
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.MainForm;
using SandO.Entities.Db;
using SandO.Entities.Enums;

namespace SandO.WinForms.Forms.Organization
{
    public partial class XtraFormDepartment : XtraForm
    {
        public string FormObjectDesc => "Departman";
        public Department Department { get; private set; }
        public int ObjId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }

        public XtraFormDepartment()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormDepartment(int objId, FormOpenOption formOpenOption)
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
            if (Department == null || Department.Id == 0)
            {
                return false;
            }


            Text = FormOpenOption switch
            {
                FormOpenOption.View => $"{FormObjectDesc} - {Department.Name}",
                FormOpenOption.Update => $"{FormObjectDesc} - {Department.Name}",
                FormOpenOption.Create => $"Yeni {FormObjectDesc}",
                _ => Text
            };

            textEditName.Text = Department.Name;
            textEditCode.Text = Department.Code;

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
                Department = new Department();
                return false;
            }

            CompanyManager companyManager = new CompanyManager();
            QueryResult<Department> queryResult = companyManager.GetDepartment(ObjId);
            if (queryResult.Result)
            {
                Department = queryResult.ResultObject;
                return true;
            }

            ribbonControl.SetMessage(queryResult.Message, MessageType.Error);
            return false;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Department.Name = textEditName.Text;
            Department.Code = textEditCode.Text;

            CompanyManager companyManager = new CompanyManager();
            WaitFormMain.ShowWaitForm();
            switch (FormOpenOption)
            {
                case FormOpenOption.Create:
                    ProgressResult = companyManager.AddDepartment(Department);
                    break;
                case FormOpenOption.Update:
                    ProgressResult = companyManager.UpdateDepartment(Department);
                    break;
                case FormOpenOption.View:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(Department.Guid, typeof(Department));
            xtraFormRecordLogs.ShowDialog();
        }
    }
}