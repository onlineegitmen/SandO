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
using SandO.Entities.AppClasses;
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.MainForm;
using SandO.Entities.Db;
using SandO.Entities.Enums;

namespace SandO.WinForms.Templates
{
    public partial class XtraFormTemp : XtraForm
    {
        public string FormObjectDesc => "Üreti Yeri";
        public TempClass TempClass { get; private set; }
        public int ObjId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }

        public XtraFormTemp()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormTemp(int objId, FormOpenOption formOpenOption)
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
            if (TempClass == null || TempClass.Id == 0)
            {
                return false;
            }


            Text = FormOpenOption switch
            {
                FormOpenOption.View => $"{FormObjectDesc} - {TempClass.Name}",
                FormOpenOption.Update => $"{FormObjectDesc} - {TempClass.Name}",
                FormOpenOption.Create => $"Yeni {FormObjectDesc}",
                _ => Text
            };


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
                TempClass = new TempClass();
                return false;
            }

            // Get object from database

            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Save button clicked.");
            ProgressResult.Result = true;
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
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(TempClass.Guid, typeof(TempClass));
            xtraFormRecordLogs.ShowDialog();
        }
    }
}