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
using SandO.Entities.AppClasses.Organization;
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.MainForm;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.WinForms.Forms.UserGroup.UserControl;

namespace SandO.WinForms.Forms.UserGroup
{
    public partial class XtraFormUser : XtraForm
    {
        public string FormObjectDesc => "Kullanıcı";
        public User User { get; private set; }
        public int UserId { get; }
        public ProgressResult ProgressResult { get; set; }
        public FormOpenOption FormOpenOption { get; }

        private List<Group> Groups { get; set; }

        public XtraFormUser()
        {
            InitializeComponent();
            FormOpenOption = FormOpenOption.Create;
            ProgressResult = new ProgressResult(false);
        }

        public XtraFormUser(int userId, FormOpenOption formOpenOption)
        {
            InitializeComponent();
            UserId = userId;
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
            GetGroupsForToken();

            ribbonControl.SetRibbonStyle();
            this.SetEditableStatus(FormOpenOption.IsReadOnly());
            SetControlsVisible();

            WaitFormMain.CloseWaitForm();
        }

        private void GetGroupsForToken()
        {
            UserGroupManager userGroupManager = new UserGroupManager();
            QueryResult<List<Group>> queryResult = userGroupManager.GetGroups();
            if (queryResult.Result)
            {
                List<int> userGroupIds = User.UserGroups == null ? new List<int>() : (User.UserGroups.Select(x => x.GroupId).ToList());
                Groups = queryResult.ResultObject.Where(g => !userGroupIds.Contains(g.Id)).ToList();
                tokenEditGroups.Properties.Tokens.AddRange(Groups);
            }
            else
            {
                XtraMessageBox.Show(queryResult.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlsVisible()
        {
            barButtonItemSave.Visibility = FormOpenOption.IsReadOnly() ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItemViewLogs.Visibility = FormOpenOption != FormOpenOption.Create ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            barButtonItemCancel.Caption = FormOpenOption.IsReadOnly() ? "Kapat" : "İptal";

            PermissionManager permissionManager = new PermissionManager();
            BoolState assignGroupPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.AssignUserOrGroup);

            if (FormOpenOption.IsReadOnly() || assignGroupPermission != BoolState.True)
            {
                groupControlAddGroups.CustomHeaderButtons.ForEach(b => b.Properties.Visible = false);
                groupControlUserGroups.CustomHeaderButtons.ForEach(b => b.Properties.Visible = false);
                tokenEditGroups.Properties.ReadOnly = true;
            }

            assignGroupPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.AssignDepartmentsToUser);
            if (FormOpenOption.IsReadOnly() || assignGroupPermission != BoolState.True)
            {
                groupControlDepartments.CustomHeaderButtons.ForEach(b => b.Properties.Visible = false);
            }
        }

        private bool SetValues()
        {
            if (User == null || User.Id == 0)
            {
                return false;
            }


            Text = FormOpenOption switch
            {
                FormOpenOption.View => $"{FormObjectDesc} - {User.Fullname}",
                FormOpenOption.Update => $"{FormObjectDesc} - {User.Fullname}",
                FormOpenOption.Create => $"Yeni {FormObjectDesc}",
                _ => Text
            };

            textEditUsername.Text = User.Username;
            textEditName.Text = User.Firstname;
            textEditSurname.Text = User.Lastname;
            textEditPhone.Text = User.Phone;
            textEditEmail.Text = User.EMail;
            dateEditExpiredAt.EditValue = User.ExpiredAt;

            userGroupBindingSource.DataSource = User.UserGroups;
            userDepartmentBindingSource.DataSource = User.UserDepartments;

            return true;
        }

        private bool GetMasterDatas()
        {

            return true;
        }

        private bool GetObject()
        {
            if (UserId == 0)
            {
                User = new User();
                return false;
            }

            UserGroupManager userGroupManager = new UserGroupManager();
            QueryResult<User> queryResult = userGroupManager.GetUserById(UserId);
            User = queryResult.Result ? queryResult.ResultObject : new User();

            return true;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            User.Username = textEditUsername.Text;
            User.Firstname = textEditName.Text;
            User.Lastname = textEditSurname.Text;
            User.Phone = textEditPhone.Text;
            User.EMail = textEditEmail.Text;
            User.ExpiredAt = (DateTime?)dateEditExpiredAt.EditValue;

            WaitFormMain.ShowWaitForm();
            UserGroupManager userGroupManager = new UserGroupManager();
            if (FormOpenOption == FormOpenOption.Create)
            {
                ProgressResult = userGroupManager.AddUser(User);
            }
            else if (FormOpenOption == FormOpenOption.Update)
            {
                ProgressResult = userGroupManager.UpdateUser(User);
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
            XtraFormRecordLogs xtraFormRecordLogs = new XtraFormRecordLogs(User.Guid, typeof(User));
            xtraFormRecordLogs.ShowDialog();
        }

        private void groupControlAddGroups_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            User.UserGroups ??= new List<Entities.Db.UserGroup>();

            List<Group> selectedGroups = tokenEditGroups.SelectedItems.Select(t => t.Value).Cast<Group>().ToList();
            foreach (Group group in selectedGroups)
            {
                Entities.Db.UserGroup userGroup = new Entities.Db.UserGroup
                {
                    UserId = User.Id,
                    GroupId = group.Id,
                    Group = group,
                };
                User.UserGroups.Add(userGroup);
            }

            userGroupBindingSource.DataSource = User.UserGroups;
            gridControlUserGroups.RefreshDataSource();

            tokenEditGroups.Properties.Tokens.Clear();
            tokenEditGroups.EditValue = null;
            Groups = Groups.Where(g => !selectedGroups.Select(s => s.Id).Contains(g.Id)).ToList();
            tokenEditGroups.Properties.Tokens.AddRange(Groups);

        }

        private void groupControlUserGroups_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Entities.Db.UserGroup focusedRow = gridViewUserGroups.GetFocusedRow() as Entities.Db.UserGroup;
            if (focusedRow == null)
            {
                return;
            }

            User.UserGroups.Remove(focusedRow);
            userGroupBindingSource.DataSource = User.UserGroups;
            gridControlUserGroups.RefreshDataSource();
            Group group = new Group
            {
                Id = focusedRow.GroupId,
                Name = focusedRow.Group.Name
            };
            tokenEditGroups.Properties.Tokens.Add(new TokenEditToken(group));
        }

        private void groupControlDepartments_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Seçili Atamayı Sil")
            {
                UserDepartment userDepartment = gridViewUserDepartments.GetFocusedRow() as UserDepartment;
                if (userDepartment == null)
                {
                    return;
                }

                userDepartment.Active = false;
            }
            else if (e.Button.Properties.Caption == "Departman Ekle")
            {
                XtraUcUserDepartment xtraUcUserDepartment = new XtraUcUserDepartment();
                DialogResult dialogResult = XtraDialog.Show(xtraUcUserDepartment, "Atanacak Görev Ayrıntıları", MessageBoxButtons.OKCancel,
                    MessageBoxDefaultButton.Button2);
                if (dialogResult != DialogResult.OK || xtraUcUserDepartment.UserDepartment == null)
                {
                    return;
                }

                UserDepartment selecteDepartment = xtraUcUserDepartment.UserDepartment;

                if (User.UserDepartments.Any(ud => ud.CompanyId == selecteDepartment.CompanyId && ud.PlantId == selecteDepartment.PlantId && ud.DepartmentId == selecteDepartment.DepartmentId && ud.AppellationId == selecteDepartment.AppellationId))
                {
                    return;
                }

                selecteDepartment.UserId = User.Id;
                selecteDepartment.User = User;

                User.UserDepartments.Add(selecteDepartment);
            }

            gridControlUserDepartments.RefreshDataSource();
        }
    }
}