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
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.MainForm;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using EnumExtensions = SandO.Entities.Enums.EnumExtensions;

namespace SandO.WinForms.Forms.UserGroup
{
    public partial class XtraFormGroup : XtraForm
    {
        public string FormObjectDesc => "Grup";
        public Group Group { get; private set; }
        public int ObjId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }

        public XtraFormGroup()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormGroup(int objId, FormOpenOption formOpenOption)
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
            barButtonItemViewLogs.Visibility = FormOpenOption != FormOpenOption.Create ? BarItemVisibility.Always : BarItemVisibility.Never;
            barButtonItemPermissions.Visibility = FormOpenOption != FormOpenOption.Create ? BarItemVisibility.Always : BarItemVisibility.Never;

            barButtonItemCancel.Caption = FormOpenOption.IsReadOnly() ? "Kapat" : "İptal";


            if (barButtonItemPermissions.Visibility == BarItemVisibility.Always)
            {
                PermissionManager permissionManager = new PermissionManager();
                BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.AssignedPermissions);
                barButtonItemPermissions.Enabled = hasPermission == BoolState.True;
            }
        }

        private bool SetValues()
        {
            Text = FormOpenOption switch
            {
                FormOpenOption.View => $"{FormObjectDesc} - {Group.Name}",
                FormOpenOption.Update => $"{FormObjectDesc} - {Group.Name}",
                FormOpenOption.Create => $"Yeni {FormObjectDesc}",
                _ => Text
            };

            if (Group == null || Group.Id == 0)
            {
                return false;
            }


            textEditName.Text = Group.Name;
            memoEditDesc.Text = Group.Desc;
            checkEditDisableAllPermissions.Checked = Group.DisabledAllPermissions;
            foreach (EnumExtensions.ModuleView propertiesItem in comboBoxEditModule.Properties.Items)
            {
                if (propertiesItem.Module == Group.GroupModule)
                {
                    comboBoxEditModule.SelectedItem = propertiesItem;
                    break;
                }
            }


            return true;
        }

        private bool GetMasterDatas()
        {
            List<EnumExtensions.ModuleView> moduleViews = EnumExtensions.ModuleView.GetModuleViews();
            comboBoxEditModule.Properties.Items.AddRange(moduleViews);

            return true;
        }

        private bool GetObject()
        {
            if (ObjId == 0)
            {
                Group = new Group();
                return false;
            }

            UserGroupManager userGroupManager = new UserGroupManager();
            QueryResult<Group> queryResult = userGroupManager.GetGroupById(ObjId, false);
            if (!queryResult.Result)
            {
                XtraMessageBox.Show(queryResult.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Group = queryResult.ResultObject;

            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            EnumExtensions.ModuleView moduleView = comboBoxEditModule.SelectedItem as EnumExtensions.ModuleView;
            if (moduleView == null)
            {
                XtraMessageBox.Show("Modül seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Group.Name = textEditName.Text;
            Group.Desc = memoEditDesc.Text;
            Group.DisabledAllPermissions = checkEditDisableAllPermissions.Checked;
            Group.GroupModule = moduleView.Module;

            WaitFormMain.ShowWaitForm();
            UserGroupManager userGroupManager = new UserGroupManager();
            ProgressResult = FormOpenOption switch
            {
                FormOpenOption.Create => userGroupManager.AddGroup(Group),
                FormOpenOption.Update => userGroupManager.UpdateGroup(Group),
                _ => ProgressResult
            };
            WaitFormMain.CloseWaitForm();

            if (ProgressResult.Result)
            {
                Close();
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
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(Group.Guid, typeof(Group));
            xtraFormRecordLogs.ShowDialog();
        }

        private void barButtonItemPermissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            XtraFormGroupPermissions xtraFormGroupPermissions = new XtraFormGroupPermissions(Group.Id, FormOpenOption);
            xtraFormGroupPermissions.ShowDialog();
        }
    }
}