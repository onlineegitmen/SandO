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
using DevExpress.DataAccess.Wizard.Model;

namespace SandO.WinForms.Forms.UserGroup
{
    public partial class XtraFormGroupPermissions : XtraForm
    {
        public Group Group { get; set; }
        public int GroupId { get; }
        public ProgressResult ProgressResult { get; private set; }
        public FormOpenOption FormOpenOption { get; }

        public XtraFormGroupPermissions(int groupId, FormOpenOption formOpenOption)
        {
            InitializeComponent();
            GroupId = groupId;
            FormOpenOption = formOpenOption;
            ProgressResult = new ProgressResult(false);
        }

        private void XtraFormTemp_Load(object sender, EventArgs e)
        {
            XtraFormMain xtraFormMain = ActiveForm as XtraFormMain;
            IconOptions.Icon = xtraFormMain?.IconOptions.Icon;

            GetObject();
            GetMasterDatas();
            SetValues();


            ribbonControl.SetRibbonStyle();
            this.SetEditableStatus(FormOpenOption.IsReadOnly());
            SetControlsVisible();

            WaitFormMain.CloseWaitForm();
        }

        private void SetControlsVisible()
        {
            barButtonItemSave.Visibility = FormOpenOption.IsReadOnly() ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;

            barButtonItemCancel.Caption = FormOpenOption.IsReadOnly() ? "Kapat" : "İptal";

            checkedListBoxControlAuthEvent.ReadOnly = FormOpenOption.IsReadOnly();
        }

        private bool SetValues()
        {



            return true;
        }

        private bool GetMasterDatas()
        {
            Tuple<List<AuthenticationClass>, List<AuthenticationClassView>> authenticationEventViews = Group.GroupModule.GetAuthenticationEventViews();
            List<AuthenticationClassView> authenticationClassViews =
                authenticationEventViews.Item2.OrderBy(v => v.Name).ToList();
            foreach (AuthenticationClassView authenticationClassView in authenticationClassViews)
            {
                listBoxControlAuthClass.Items.Add(authenticationClassView);
            }
            return true;
        }

        private bool GetObject()
        {
            UserGroupManager userGroupManager = new UserGroupManager();
            QueryResult<Group> groupById = userGroupManager.GetGroupById(GroupId, true);
            if (groupById.Result)
            {
                Group = groupById.ResultObject;
            }
            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            UserGroupManager userGroupManager = new UserGroupManager();
            ProgressResult = userGroupManager.SaveGroupPermissions(Group.GroupPermissions, GroupId);
            WaitFormMain.CloseWaitForm();
            ProgressResult.Show();
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

        private void listBoxControlAuthClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxControlAuthEvent.Items.Clear();
            AuthenticationClassView authenticationClassView = listBoxControlAuthClass.SelectedItem as AuthenticationClassView;
            if (authenticationClassView == null)
            {
                return;
            }

            Tuple<List<AuthenticationEvent>, List<AuthenticationEventView>> authenticationEventViews = authenticationClassView.AuthenticationClass.GetAuthenticationEventViews();
            List<AuthenticationEventView> authenticationEventViewList = authenticationEventViews.Item2.OrderBy(v => v.Name).ToList();
            foreach (AuthenticationEventView authenticationEventView in authenticationEventViewList)
            {
                bool any = Group.GroupPermissions.Any(p =>
                    p.AuthenticationClass == authenticationClassView.AuthenticationClass &&
                    p.AuthenticationEvent == authenticationEventView.AuthenticationEvent);
                checkedListBoxControlAuthEvent.Items.Add(authenticationEventView, any);
            }

            groupControlPerEvent.Text = $"Yetki ({authenticationClassView.Name})";
        }

        private void checkedListBoxControlAuthEvent_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            AuthenticationClassView authenticationClassView = listBoxControlAuthClass.SelectedItem as AuthenticationClassView;
            if (authenticationClassView == null)
            {
                return;
            }

            Group.GroupPermissions.RemoveAll(p => p.AuthenticationClass == authenticationClassView.AuthenticationClass);


            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem checkedItem in checkedListBoxControlAuthEvent.CheckedItems)
            {
                AuthenticationEventView authenticationEventView = checkedItem.Value as AuthenticationEventView;
                if (authenticationEventView == null)
                {
                    continue;
                }

                GroupPermission groupPermission = new GroupPermission
                {
                    AuthenticationClass = authenticationClassView.AuthenticationClass,
                    AuthenticationEvent = authenticationEventView.AuthenticationEvent,
                    GroupId = GroupId
                };
                Group.GroupPermissions.Add(groupPermission);
            }
        }
    }
}