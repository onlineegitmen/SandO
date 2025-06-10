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
    public partial class XtraFormAppellation : XtraForm
    {
        public string FormObjectDesc => "Ünvan";
        public Appellation Appellation { get; private set; }
        public int ObjId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }

        public XtraFormAppellation()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormAppellation(int objId, FormOpenOption formOpenOption)
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
            barButtonItemViewLogs.Visibility = FormOpenOption == FormOpenOption.Create ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;

            barButtonItemCancel.Caption = FormOpenOption.IsReadOnly() ? "Kapat" : "İptal";
        }

        private bool SetValues()
        {
            if (Appellation == null || Appellation.Id == 0)
            {
                return false;
            }


            Text = FormOpenOption switch
            {
                FormOpenOption.View => $"{FormObjectDesc} - {Appellation.Name}",
                FormOpenOption.Update => $"{FormObjectDesc} - {Appellation.Name}",
                FormOpenOption.Create => $"Yeni {FormObjectDesc}",
                _ => Text
            };

            textEditCode.Text = Appellation.Code;
            textEditName.Text = Appellation.Name;
            memoEditDesc.Text = Appellation.Description;

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
                Appellation = new Appellation();
                return false;
            }

            CompanyManager companyManager = new CompanyManager();
            QueryResult<Appellation> queryResult = companyManager.GetAppellation(ObjId);
            if (!queryResult.Result)
            {
                ribbonControl.SetMessage(queryResult.Message, MessageType.Error);
                return false;
            }

            Appellation = queryResult.ResultObject;
            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Appellation.Code = textEditCode.Text;
            Appellation.Name = textEditName.Text;
            Appellation.Description = memoEditDesc.Text;

            CompanyManager companyManager = new CompanyManager();
            WaitFormMain.ShowWaitForm();
            switch (FormOpenOption)
            {
                case FormOpenOption.Create:
                    ProgressResult = companyManager.AddAppellation(Appellation);
                    break;
                case FormOpenOption.Update:
                    ProgressResult = companyManager.UpdateAppellation(Appellation);
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(Appellation.Guid, typeof(Appellation));
            xtraFormRecordLogs.ShowDialog();
        }
    }
}