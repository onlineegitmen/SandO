namespace SandO.WinForms.MainForm
{
    partial class XtraFormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            barSubItemOrganization = new DevExpress.XtraBars.BarSubItem();
            barSubItemCompany = new DevExpress.XtraBars.BarSubItem();
            barButtonItemAddCompany = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemCompanies = new DevExpress.XtraBars.BarButtonItem();
            barSubItemPlant = new DevExpress.XtraBars.BarSubItem();
            barButtonItemAddPlant = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemPlants = new DevExpress.XtraBars.BarButtonItem();
            barSubItemDepartments = new DevExpress.XtraBars.BarSubItem();
            barButtonItemAddDepartment = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDepartments = new DevExpress.XtraBars.BarButtonItem();
            barSubItemAppellations = new DevExpress.XtraBars.BarSubItem();
            barButtonItemAddAppellation = new DevExpress.XtraBars.BarButtonItem();
            barSubItemUsergroups = new DevExpress.XtraBars.BarSubItem();
            barButtonItemAddGroup = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemGroups = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemAddUser = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemUsers = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemSetAdminPermissions = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItemInfo = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemGetAppellations = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)applicationMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // xtraTabbedMdiManager
            // 
            xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            xtraTabbedMdiManager.MdiParent = this;
            // 
            // applicationMenu1
            // 
            applicationMenu1.Name = "applicationMenu1";
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barSubItemOrganization, barSubItemCompany, barButtonItemAddCompany, barStaticItemInfo, barButtonItemSetAdminPermissions, barButtonItemCompanies, barSubItemUsergroups, barButtonItemAddGroup, barButtonItemGroups, barButtonItemAddUser, barButtonItemUsers, barButtonItem1, barSubItemPlant, barButtonItemAddPlant, barButtonItemPlants, barSubItemDepartments, barButtonItemAddDepartment, barButtonItemDepartments, barSubItemAppellations, barButtonItemAddAppellation, barButtonItemGetAppellations });
            barManager1.MaxItemId = 22;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barSubItemOrganization), new DevExpress.XtraBars.LinkPersistInfo(barSubItemUsergroups), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemSetAdminPermissions) });
            bar1.Text = "Tools";
            // 
            // barSubItemOrganization
            // 
            barSubItemOrganization.Caption = "Organizasyon Yapısı";
            barSubItemOrganization.Id = 0;
            barSubItemOrganization.ImageOptions.Image = Properties.Resources.treeview_16x16;
            barSubItemOrganization.ImageOptions.LargeImage = Properties.Resources.treeview_32x32;
            barSubItemOrganization.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barSubItemCompany), new DevExpress.XtraBars.LinkPersistInfo(barSubItemPlant), new DevExpress.XtraBars.LinkPersistInfo(barSubItemDepartments), new DevExpress.XtraBars.LinkPersistInfo(barSubItemAppellations) });
            barSubItemOrganization.Name = "barSubItemOrganization";
            barSubItemOrganization.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItemCompany
            // 
            barSubItemCompany.Caption = "Şirket İşlemleri";
            barSubItemCompany.Id = 1;
            barSubItemCompany.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAddCompany), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemCompanies) });
            barSubItemCompany.Name = "barSubItemCompany";
            // 
            // barButtonItemAddCompany
            // 
            barButtonItemAddCompany.Caption = "Şirket Ekle";
            barButtonItemAddCompany.Id = 2;
            barButtonItemAddCompany.Name = "barButtonItemAddCompany";
            barButtonItemAddCompany.ItemClick += barButtonItemAddCompany_ItemClick;
            // 
            // barButtonItemCompanies
            // 
            barButtonItemCompanies.Caption = "Şirketler";
            barButtonItemCompanies.Id = 5;
            barButtonItemCompanies.Name = "barButtonItemCompanies";
            barButtonItemCompanies.ItemClick += barButtonItemCompanies_ItemClick;
            // 
            // barSubItemPlant
            // 
            barSubItemPlant.Caption = "Üretim Yeri İşlemleri";
            barSubItemPlant.Id = 13;
            barSubItemPlant.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAddPlant), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemPlants) });
            barSubItemPlant.Name = "barSubItemPlant";
            // 
            // barButtonItemAddPlant
            // 
            barButtonItemAddPlant.Caption = "Üretim Yeri Ekle";
            barButtonItemAddPlant.Id = 14;
            barButtonItemAddPlant.Name = "barButtonItemAddPlant";
            barButtonItemAddPlant.ItemClick += barButtonItemAddPlant_ItemClick;
            // 
            // barButtonItemPlants
            // 
            barButtonItemPlants.Caption = "Üretim Yerleri";
            barButtonItemPlants.Id = 15;
            barButtonItemPlants.Name = "barButtonItemPlants";
            barButtonItemPlants.ItemClick += barButtonItemPlants_ItemClick;
            // 
            // barSubItemDepartments
            // 
            barSubItemDepartments.Caption = "Departman İşlemleri";
            barSubItemDepartments.Id = 16;
            barSubItemDepartments.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAddDepartment), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDepartments) });
            barSubItemDepartments.Name = "barSubItemDepartments";
            // 
            // barButtonItemAddDepartment
            // 
            barButtonItemAddDepartment.Caption = "Departman Ekle";
            barButtonItemAddDepartment.Id = 17;
            barButtonItemAddDepartment.Name = "barButtonItemAddDepartment";
            barButtonItemAddDepartment.ItemClick += barButtonItemAddDepartment_ItemClick;
            // 
            // barButtonItemDepartments
            // 
            barButtonItemDepartments.Caption = "Departmanlar";
            barButtonItemDepartments.Id = 18;
            barButtonItemDepartments.Name = "barButtonItemDepartments";
            barButtonItemDepartments.ItemClick += barButtonItemDepartments_ItemClick;
            // 
            // barSubItemAppellations
            // 
            barSubItemAppellations.Caption = "Ünvanlar";
            barSubItemAppellations.Id = 19;
            barSubItemAppellations.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAddAppellation), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemGetAppellations) });
            barSubItemAppellations.Name = "barSubItemAppellations";
            // 
            // barButtonItemAddAppellation
            // 
            barButtonItemAddAppellation.Caption = "Ünvan Ekle";
            barButtonItemAddAppellation.Id = 20;
            barButtonItemAddAppellation.Name = "barButtonItemAddAppellation";
            barButtonItemAddAppellation.ItemClick += barButtonItemAddAppellation_ItemClick;
            // 
            // barSubItemUsergroups
            // 
            barSubItemUsergroups.Caption = "Kullanıcı && Grup";
            barSubItemUsergroups.Id = 6;
            barSubItemUsergroups.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAddGroup), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemGroups), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAddUser), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemUsers) });
            barSubItemUsergroups.Name = "barSubItemUsergroups";
            // 
            // barButtonItemAddGroup
            // 
            barButtonItemAddGroup.Caption = "Grup Ekle";
            barButtonItemAddGroup.Id = 7;
            barButtonItemAddGroup.Name = "barButtonItemAddGroup";
            barButtonItemAddGroup.ItemClick += barButtonItemAddGroup_ItemClick;
            // 
            // barButtonItemGroups
            // 
            barButtonItemGroups.Caption = "Gruplar";
            barButtonItemGroups.Id = 8;
            barButtonItemGroups.Name = "barButtonItemGroups";
            barButtonItemGroups.ItemClick += barButtonItemGroups_ItemClick;
            // 
            // barButtonItemAddUser
            // 
            barButtonItemAddUser.Caption = "Kullanıcı Ekle";
            barButtonItemAddUser.Id = 9;
            barButtonItemAddUser.Name = "barButtonItemAddUser";
            barButtonItemAddUser.ItemClick += barButtonItemAddUser_ItemClick;
            // 
            // barButtonItemUsers
            // 
            barButtonItemUsers.Caption = "Kullanıcılar";
            barButtonItemUsers.Id = 10;
            barButtonItemUsers.Name = "barButtonItemUsers";
            barButtonItemUsers.ItemClick += barButtonItemUsers_ItemClick;
            // 
            // barButtonItemSetAdminPermissions
            // 
            barButtonItemSetAdminPermissions.Caption = "Yönetici Yetkilerini Ayarla";
            barButtonItemSetAdminPermissions.Id = 4;
            barButtonItemSetAdminPermissions.Name = "barButtonItemSetAdminPermissions";
            barButtonItemSetAdminPermissions.ItemClick += barButtonItemSetAdminPermissions_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barStaticItemInfo) });
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barStaticItemInfo
            // 
            barStaticItemInfo.Caption = "barStaticItem1";
            barStaticItemInfo.Id = 3;
            barStaticItemInfo.ImageOptions.Image = Properties.Resources.save_16x16;
            barStaticItemInfo.Name = "barStaticItemInfo";
            barStaticItemInfo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(929, 25);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 668);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(929, 27);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 643);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(929, 25);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 643);
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Üretim Yeri İşlemleri";
            barButtonItem1.Id = 12;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItemGetAppellations
            // 
            barButtonItemGetAppellations.Caption = "Ünvanlar";
            barButtonItemGetAppellations.Id = 21;
            barButtonItemGetAppellations.Name = "barButtonItemGetAppellations";
            barButtonItemGetAppellations.ItemClick += barButtonItemGetAppellations_ItemClick;
            // 
            // XtraFormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(929, 695);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IsMdiContainer = true;
            Name = "XtraFormMain";
            Text = "Form1";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += XtraFormMain_Load;
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)applicationMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem barSubItemOrganization;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarSubItem barSubItemCompany;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddCompany;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSetAdminPermissions;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCompanies;
        private DevExpress.XtraBars.BarSubItem barSubItemUsergroups;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddGroup;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGroups;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddUser;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUsers;
        private DevExpress.XtraBars.BarSubItem barSubItemPlant;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddPlant;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPlants;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItemDepartments;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddDepartment;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDepartments;
        private DevExpress.XtraBars.BarSubItem barSubItemAppellations;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddAppellation;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGetAppellations;
    }
}

