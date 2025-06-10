using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using SandO.Bll;
using SandO.Bll.Helpers;
using SandO.Bll.Managers;
using SandO.Entities.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;
using SandO.WinForms.Forms.Organization;
using SandO.WinForms.Forms.UserGroup;

namespace SandO.WinForms.MainForm
{
    public partial class XtraFormMain : XtraForm
    {
        public XtraFormMain()
        {
            InitializeComponent();
        }

        private void XtraFormMain_Load(object sender, EventArgs e)
        {
            Text = GlobalVariables.ProjectName;
            barStaticItemInfo.Caption = GlobalVariables.ProjectName;
        }

        bool OpenSingleForm(XtraForm xtraForm)
        {
            Form form = MdiChildren.FirstOrDefault(f => f.Text == xtraForm.Text);
            if (form == null)
            {
                xtraForm.Load += (sender, e) =>
                {
                    WaitFormMain.CloseWaitForm();
                };
                xtraForm.MdiParent = this;
                xtraForm.Show();
                return true;
            }

            form.Activate();
            WaitFormMain.CloseWaitForm();
            return false;
        }

        bool HasPermission(AuthenticationClass authenticationClass)
        {
            WaitFormMain.ShowWaitForm(description: "Yetki sorgulanıyor");
            PermissionManager permissionManager = new PermissionManager();
            BoolState boolState = permissionManager.HasAnyPermission(authenticationClass);
            switch (boolState)
            {
                case BoolState.NotDefined:
                    barStaticItemInfo.Caption = "Yetki sorgulama hatası";
                    barStaticItemInfo.ImageOptions.Image = Properties.Resources.close_16x16;
                    break;
                case BoolState.True:
                    barStaticItemInfo.Caption = GlobalVariables.ProjectName;
                    barStaticItemInfo.ImageOptions.Image = Properties.Resources.new_16x16;
                    break;
                case BoolState.False:
                    barStaticItemInfo.Caption = "Bu ekran için yetkiniz yok";
                    barStaticItemInfo.ImageOptions.Image = Properties.Resources.close_16x16;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            WaitFormMain.CloseWaitForm();
            return boolState == BoolState.True;
        }

        bool HasPermission(AuthenticationClass authenticationClass, AuthenticationEvent authenticationEvent)
        {
            WaitFormMain.ShowWaitForm(description: "Yetki sorgulanıyor");
            PermissionManager permissionManager = new PermissionManager();
            BoolState boolState = permissionManager.HasPermission(authenticationClass, authenticationEvent);
            switch (boolState)
            {
                case BoolState.NotDefined:
                    barStaticItemInfo.Caption = "Yetki sorgulama hatası";
                    barStaticItemInfo.ImageOptions.Image = Properties.Resources.close_16x16;
                    break;
                case BoolState.True:
                    barStaticItemInfo.Caption = GlobalVariables.ProjectName;
                    barStaticItemInfo.ImageOptions.Image = Properties.Resources.new_16x16;
                    break;
                case BoolState.False:
                    barStaticItemInfo.Caption = "Bu ekran için yetkiniz yok";
                    barStaticItemInfo.ImageOptions.Image = Properties.Resources.close_16x16;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            WaitFormMain.CloseWaitForm();
            return boolState == BoolState.True;
        }

        private void barButtonItemAddCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Company, AuthenticationEvent.Create))
            {
                return;
            }

            XtraFormCompany xtraFormCompany = new XtraFormCompany();
            xtraFormCompany.ShowDialog();
        }

        private void barButtonItemSetAdminPermissions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            PermissionManager permissionManager = new PermissionManager();
            permissionManager.CreateAllPermissionsForAdminGroup();
            WaitFormMain.CloseWaitForm();

            XtraMessageBox.Show("Admin yetkileri oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            NewtonJsonHelper.RestoreColumnDescription();
            XtraMessageBox.Show("Açıklama bilgileri geri yüklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barButtonItemCompanies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Company, AuthenticationEvent.CanManage))
            {
                return;
            }

            XtraFormCompanies xtraFormCompanies = new XtraFormCompanies();
            OpenSingleForm(xtraFormCompanies);
        }

        private void barButtonItemAddGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Create))
            {
                return;
            }

            XtraFormGroup xtraFormUserGroup = new XtraFormGroup();
            xtraFormUserGroup.ShowDialog();
            xtraFormUserGroup.ProgressResult.Show();
        }

        private void barButtonItemGroups_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.CanManage))
            {
                return;
            }

            XtraFormGroups xtraFormGroups = new XtraFormGroups();
            OpenSingleForm(xtraFormGroups);
        }

        private void barButtonItemAddUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Create))
            {
                return;
            }

            XtraFormUser xtraFormUser = new XtraFormUser();
            xtraFormUser.ShowDialog();
            xtraFormUser.ProgressResult.Show();
        }

        private void barButtonItemUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.CanManage))
            {
                return;
            }

            XtraFormUsers xtraFormUsers = new XtraFormUsers();
            OpenSingleForm(xtraFormUsers);
        }

        private void barButtonItemAddPlant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Create))
            {
                return;
            }

            XtraFormPlant xtraFormPlant = new XtraFormPlant();
            xtraFormPlant.ShowDialog();
            xtraFormPlant.ProgressResult.Show();
        }

        private void barButtonItemPlants_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Plant, AuthenticationEvent.CanManage))
            {
                return;
            }
            XtraFormPlants xtraFormPlants = new XtraFormPlants();
            OpenSingleForm(xtraFormPlants);
        }

        private void barButtonItemAddDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Department, AuthenticationEvent.Create))
            {
                return;
            }

            XtraFormDepartment xtraFormDepartment = new XtraFormDepartment();
            xtraFormDepartment.ShowDialog();
            xtraFormDepartment.ProgressResult.Show();
        }

        private void barButtonItemDepartments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Department, AuthenticationEvent.CanManage))
            {
                return;
            }
            XtraFormDepartments xtraFormDepartments = new XtraFormDepartments();
            OpenSingleForm(xtraFormDepartments);
        }

        private void barButtonItemAddAppellation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.Create))
            {
                return;
            }

            XtraFormAppellation xtraFormAppellation = new XtraFormAppellation();
            xtraFormAppellation.ShowDialog();
            xtraFormAppellation.ProgressResult.Show();
        }

        private void barButtonItemGetAppellations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.CanManage))
            {
                return;
            }
            XtraFormAppellations xtraFormAppellations = new XtraFormAppellations();
            OpenSingleForm(xtraFormAppellations);
        }
    }
}
