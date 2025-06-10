namespace SandO.WinForms.Forms.UserGroup
{
    partial class XtraFormUser
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions4 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemCancel = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemViewLogs = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPageMetaData = new DevExpress.XtraTab.XtraTabPage();
            dateEditExpiredAt = new DevExpress.XtraEditors.DateEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            textEditEmail = new DevExpress.XtraEditors.TextEdit();
            textEditPhone = new DevExpress.XtraEditors.TextEdit();
            textEditSurname = new DevExpress.XtraEditors.TextEdit();
            textEditName = new DevExpress.XtraEditors.TextEdit();
            textEditUsername = new DevExpress.XtraEditors.TextEdit();
            xtraTabPageUserGroups = new DevExpress.XtraTab.XtraTabPage();
            groupControlUserGroups = new DevExpress.XtraEditors.GroupControl();
            gridControlUserGroups = new DevExpress.XtraGrid.GridControl();
            userGroupBindingSource = new System.Windows.Forms.BindingSource(components);
            gridViewUserGroups = new DevExpress.XtraGrid.Views.Grid.GridView();
            colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            groupControlAddGroups = new DevExpress.XtraEditors.GroupControl();
            tokenEditGroups = new DevExpress.XtraEditors.TokenEdit();
            xtraTabPageDepartments = new DevExpress.XtraTab.XtraTabPage();
            groupControlDepartments = new DevExpress.XtraEditors.GroupControl();
            gridControlUserDepartments = new DevExpress.XtraGrid.GridControl();
            userDepartmentBindingSource = new System.Windows.Forms.BindingSource(components);
            gridViewUserDepartments = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlant = new DevExpress.XtraGrid.Columns.GridColumn();
            colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            colAppellation = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            colEndAt = new DevExpress.XtraGrid.Columns.GridColumn();
            colDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl).BeginInit();
            xtraTabControl.SuspendLayout();
            xtraTabPageMetaData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditExpiredAt.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditExpiredAt.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditPhone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditSurname.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditUsername.Properties).BeginInit();
            xtraTabPageUserGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlUserGroups).BeginInit();
            groupControlUserGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlUserGroups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userGroupBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUserGroups).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlAddGroups).BeginInit();
            groupControlAddGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tokenEditGroups.Properties).BeginInit();
            xtraTabPageDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlDepartments).BeginInit();
            groupControlDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlUserDepartments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userDepartmentBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUserDepartments).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, barButtonItemSave, barButtonItemCancel, barButtonItemViewLogs });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 5;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl.Size = new System.Drawing.Size(651, 150);
            // 
            // barButtonItemSave
            // 
            barButtonItemSave.Caption = "Kaydet";
            barButtonItemSave.Id = 1;
            barButtonItemSave.ImageOptions.Image = Properties.Resources.save_16x16;
            barButtonItemSave.ImageOptions.LargeImage = Properties.Resources.save_32x32;
            barButtonItemSave.Name = "barButtonItemSave";
            barButtonItemSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemSave.ItemClick += barButtonItemSave_ItemClick;
            // 
            // barButtonItemCancel
            // 
            barButtonItemCancel.Caption = "İptal";
            barButtonItemCancel.Id = 2;
            barButtonItemCancel.ImageOptions.Image = Properties.Resources.cancel_16x16;
            barButtonItemCancel.ImageOptions.LargeImage = Properties.Resources.cancel_32x32;
            barButtonItemCancel.Name = "barButtonItemCancel";
            barButtonItemCancel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemCancel.ItemClick += barButtonItemCancel_ItemClick;
            // 
            // barButtonItemViewLogs
            // 
            barButtonItemViewLogs.Caption = "Değişiklik Belgeleri";
            barButtonItemViewLogs.Id = 4;
            barButtonItemViewLogs.ImageOptions.Image = Properties.Resources.logical_32x32;
            barButtonItemViewLogs.Name = "barButtonItemViewLogs";
            barButtonItemViewLogs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemViewLogs.ItemClick += barButtonItemViewLogs_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItemSave);
            ribbonPageGroup1.ItemLinks.Add(barButtonItemCancel);
            ribbonPageGroup1.ItemLinks.Add(barButtonItemViewLogs);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // xtraTabControl
            // 
            xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            xtraTabControl.Location = new System.Drawing.Point(0, 150);
            xtraTabControl.Name = "xtraTabControl";
            xtraTabControl.SelectedTabPage = xtraTabPageMetaData;
            xtraTabControl.Size = new System.Drawing.Size(651, 511);
            xtraTabControl.TabIndex = 1;
            xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPageMetaData, xtraTabPageUserGroups, xtraTabPageDepartments });
            // 
            // xtraTabPageMetaData
            // 
            xtraTabPageMetaData.Controls.Add(dateEditExpiredAt);
            xtraTabPageMetaData.Controls.Add(labelControl6);
            xtraTabPageMetaData.Controls.Add(labelControl5);
            xtraTabPageMetaData.Controls.Add(labelControl4);
            xtraTabPageMetaData.Controls.Add(labelControl3);
            xtraTabPageMetaData.Controls.Add(labelControl2);
            xtraTabPageMetaData.Controls.Add(labelControl1);
            xtraTabPageMetaData.Controls.Add(textEditEmail);
            xtraTabPageMetaData.Controls.Add(textEditPhone);
            xtraTabPageMetaData.Controls.Add(textEditSurname);
            xtraTabPageMetaData.Controls.Add(textEditName);
            xtraTabPageMetaData.Controls.Add(textEditUsername);
            xtraTabPageMetaData.Name = "xtraTabPageMetaData";
            xtraTabPageMetaData.Size = new System.Drawing.Size(649, 486);
            xtraTabPageMetaData.Text = "Temel Bilgiler";
            // 
            // dateEditExpiredAt
            // 
            dateEditExpiredAt.EditValue = null;
            dateEditExpiredAt.Location = new System.Drawing.Point(420, 3);
            dateEditExpiredAt.MenuManager = ribbonControl;
            dateEditExpiredAt.Name = "dateEditExpiredAt";
            dateEditExpiredAt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditExpiredAt.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            dateEditExpiredAt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditExpiredAt.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            dateEditExpiredAt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditExpiredAt.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            dateEditExpiredAt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditExpiredAt.Properties.UseMaskAsDisplayFormat = true;
            dateEditExpiredAt.Size = new System.Drawing.Size(218, 20);
            dateEditExpiredAt.TabIndex = 2;
            // 
            // labelControl6
            // 
            labelControl6.Location = new System.Drawing.Point(303, 6);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(111, 13);
            labelControl6.TabIndex = 1;
            labelControl6.Text = "Hesap Geçerlilik Zamanı";
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(11, 110);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(37, 13);
            labelControl5.TabIndex = 1;
            labelControl5.Text = "E-Posta";
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(11, 84);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(36, 13);
            labelControl4.TabIndex = 1;
            labelControl4.Text = "Telefon";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(11, 58);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(32, 13);
            labelControl3.TabIndex = 1;
            labelControl3.Text = "Soyadı";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(11, 32);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(15, 13);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Adı";
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(11, 6);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(55, 13);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Kullanıcı Adı";
            // 
            // textEditEmail
            // 
            textEditEmail.Location = new System.Drawing.Point(72, 107);
            textEditEmail.Name = "textEditEmail";
            textEditEmail.Size = new System.Drawing.Size(214, 20);
            textEditEmail.TabIndex = 0;
            // 
            // textEditPhone
            // 
            textEditPhone.Location = new System.Drawing.Point(72, 81);
            textEditPhone.Name = "textEditPhone";
            textEditPhone.Size = new System.Drawing.Size(214, 20);
            textEditPhone.TabIndex = 0;
            // 
            // textEditSurname
            // 
            textEditSurname.Location = new System.Drawing.Point(72, 55);
            textEditSurname.Name = "textEditSurname";
            textEditSurname.Size = new System.Drawing.Size(214, 20);
            textEditSurname.TabIndex = 0;
            // 
            // textEditName
            // 
            textEditName.Location = new System.Drawing.Point(72, 29);
            textEditName.Name = "textEditName";
            textEditName.Size = new System.Drawing.Size(214, 20);
            textEditName.TabIndex = 0;
            // 
            // textEditUsername
            // 
            textEditUsername.Location = new System.Drawing.Point(72, 3);
            textEditUsername.MenuManager = ribbonControl;
            textEditUsername.Name = "textEditUsername";
            textEditUsername.Size = new System.Drawing.Size(214, 20);
            textEditUsername.TabIndex = 0;
            // 
            // xtraTabPageUserGroups
            // 
            xtraTabPageUserGroups.Controls.Add(groupControlUserGroups);
            xtraTabPageUserGroups.Controls.Add(groupControlAddGroups);
            xtraTabPageUserGroups.Name = "xtraTabPageUserGroups";
            xtraTabPageUserGroups.Size = new System.Drawing.Size(649, 486);
            xtraTabPageUserGroups.Text = "Grup Üyelikleri";
            // 
            // groupControlUserGroups
            // 
            groupControlUserGroups.Controls.Add(gridControlUserGroups);
            buttonImageOptions1.Image = Properties.Resources.remove_16x16;
            groupControlUserGroups.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Seçili Grubu Çıkar", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            groupControlUserGroups.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            groupControlUserGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControlUserGroups.Location = new System.Drawing.Point(0, 134);
            groupControlUserGroups.Name = "groupControlUserGroups";
            groupControlUserGroups.Size = new System.Drawing.Size(649, 352);
            groupControlUserGroups.TabIndex = 0;
            groupControlUserGroups.Text = "Grup Üyelikleri";
            groupControlUserGroups.CustomButtonClick += groupControlUserGroups_CustomButtonClick;
            // 
            // gridControlUserGroups
            // 
            gridControlUserGroups.DataSource = userGroupBindingSource;
            gridControlUserGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlUserGroups.Location = new System.Drawing.Point(2, 23);
            gridControlUserGroups.MainView = gridViewUserGroups;
            gridControlUserGroups.MenuManager = ribbonControl;
            gridControlUserGroups.Name = "gridControlUserGroups";
            gridControlUserGroups.Size = new System.Drawing.Size(645, 327);
            gridControlUserGroups.TabIndex = 0;
            gridControlUserGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewUserGroups });
            // 
            // gridViewUserGroups
            // 
            gridViewUserGroups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colUser, colGroup, colGuid });
            gridViewUserGroups.GridControl = gridControlUserGroups;
            gridViewUserGroups.Name = "gridViewUserGroups";
            gridViewUserGroups.OptionsBehavior.Editable = false;
            gridViewUserGroups.OptionsCustomization.AllowGroup = false;
            gridViewUserGroups.OptionsView.ShowGroupPanel = false;
            // 
            // colUser
            // 
            colUser.FieldName = "User.Fullname";
            colUser.Name = "colUser";
            // 
            // colGroup
            // 
            colGroup.FieldName = "Group.Name";
            colGroup.Name = "colGroup";
            colGroup.Visible = true;
            colGroup.VisibleIndex = 0;
            // 
            // colGuid
            // 
            colGuid.FieldName = "Guid";
            colGuid.Name = "colGuid";
            // 
            // groupControlAddGroups
            // 
            groupControlAddGroups.Controls.Add(tokenEditGroups);
            buttonImageOptions2.Image = Properties.Resources.add_16x16;
            groupControlAddGroups.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Seçili Grupları Ekle", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            groupControlAddGroups.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            groupControlAddGroups.Dock = System.Windows.Forms.DockStyle.Top;
            groupControlAddGroups.Location = new System.Drawing.Point(0, 0);
            groupControlAddGroups.Name = "groupControlAddGroups";
            groupControlAddGroups.Size = new System.Drawing.Size(649, 134);
            groupControlAddGroups.TabIndex = 1;
            groupControlAddGroups.Text = "Grup Ekle";
            groupControlAddGroups.CustomButtonClick += groupControlAddGroups_CustomButtonClick;
            // 
            // tokenEditGroups
            // 
            tokenEditGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            tokenEditGroups.Location = new System.Drawing.Point(2, 23);
            tokenEditGroups.MenuManager = ribbonControl;
            tokenEditGroups.Name = "tokenEditGroups";
            tokenEditGroups.Properties.Separators.AddRange(new string[] { "," });
            tokenEditGroups.Size = new System.Drawing.Size(645, 20);
            tokenEditGroups.TabIndex = 0;
            // 
            // xtraTabPageDepartments
            // 
            xtraTabPageDepartments.Controls.Add(groupControlDepartments);
            xtraTabPageDepartments.Name = "xtraTabPageDepartments";
            xtraTabPageDepartments.Size = new System.Drawing.Size(649, 486);
            xtraTabPageDepartments.Text = "Departmanlar";
            // 
            // groupControlDepartments
            // 
            groupControlDepartments.Controls.Add(gridControlUserDepartments);
            buttonImageOptions3.Image = Properties.Resources.add_16x16;
            buttonImageOptions4.Image = Properties.Resources.remove_16x16;
            groupControlDepartments.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Departman Ekle", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Seçili Atamayı Sil", true, buttonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            groupControlDepartments.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            groupControlDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControlDepartments.Location = new System.Drawing.Point(0, 0);
            groupControlDepartments.Name = "groupControlDepartments";
            groupControlDepartments.Size = new System.Drawing.Size(649, 486);
            groupControlDepartments.TabIndex = 0;
            groupControlDepartments.Text = "Kullanıcı Departmanları";
            groupControlDepartments.CustomButtonClick += groupControlDepartments_CustomButtonClick;
            // 
            // gridControlUserDepartments
            // 
            gridControlUserDepartments.DataSource = userDepartmentBindingSource;
            gridControlUserDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlUserDepartments.Location = new System.Drawing.Point(2, 23);
            gridControlUserDepartments.MainView = gridViewUserDepartments;
            gridControlUserDepartments.MenuManager = ribbonControl;
            gridControlUserDepartments.Name = "gridControlUserDepartments";
            gridControlUserDepartments.Size = new System.Drawing.Size(645, 461);
            gridControlUserDepartments.TabIndex = 0;
            gridControlUserDepartments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewUserDepartments });
            // 
            // userDepartmentBindingSource
            // 
            userDepartmentBindingSource.DataSource = typeof(Entities.Db.UserDepartment);
            // 
            // gridViewUserDepartments
            // 
            gridViewUserDepartments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCompany, colPlant, colDepartment, colAppellation, colStartFrom, colEndAt, colDefault, colActive });
            gridViewUserDepartments.GridControl = gridControlUserDepartments;
            gridViewUserDepartments.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridViewUserDepartments.Name = "gridViewUserDepartments";
            gridViewUserDepartments.OptionsBehavior.Editable = false;
            // 
            // colCompany
            // 
            colCompany.FieldName = "Company";
            colCompany.Name = "colCompany";
            colCompany.Visible = true;
            colCompany.VisibleIndex = 0;
            // 
            // colPlant
            // 
            colPlant.FieldName = "Plant";
            colPlant.Name = "colPlant";
            colPlant.Visible = true;
            colPlant.VisibleIndex = 1;
            // 
            // colDepartment
            // 
            colDepartment.FieldName = "Department";
            colDepartment.Name = "colDepartment";
            colDepartment.Visible = true;
            colDepartment.VisibleIndex = 2;
            // 
            // colAppellation
            // 
            colAppellation.FieldName = "Appellation";
            colAppellation.Name = "colAppellation";
            colAppellation.Visible = true;
            colAppellation.VisibleIndex = 3;
            // 
            // colStartFrom
            // 
            colStartFrom.FieldName = "StartFrom";
            colStartFrom.Name = "colStartFrom";
            colStartFrom.Visible = true;
            colStartFrom.VisibleIndex = 4;
            // 
            // colEndAt
            // 
            colEndAt.FieldName = "EndAt";
            colEndAt.Name = "colEndAt";
            colEndAt.Visible = true;
            colEndAt.VisibleIndex = 5;
            // 
            // colDefault
            // 
            colDefault.FieldName = "Default";
            colDefault.Name = "colDefault";
            colDefault.Visible = true;
            colDefault.VisibleIndex = 6;
            // 
            // colActive
            // 
            colActive.FieldName = "Active";
            colActive.Name = "colActive";
            colActive.Visible = true;
            colActive.VisibleIndex = 7;
            // 
            // XtraFormUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(651, 661);
            Controls.Add(xtraTabControl);
            Controls.Add(ribbonControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "XtraFormUser";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Kullanıcı";
            Load += XtraFormTemp_Load;
            KeyDown += XtraFormTemp_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl).EndInit();
            xtraTabControl.ResumeLayout(false);
            xtraTabPageMetaData.ResumeLayout(false);
            xtraTabPageMetaData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditExpiredAt.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditExpiredAt.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditPhone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditSurname.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditUsername.Properties).EndInit();
            xtraTabPageUserGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControlUserGroups).EndInit();
            groupControlUserGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlUserGroups).EndInit();
            ((System.ComponentModel.ISupportInitialize)userGroupBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUserGroups).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlAddGroups).EndInit();
            groupControlAddGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tokenEditGroups.Properties).EndInit();
            xtraTabPageDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControlDepartments).EndInit();
            groupControlDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlUserDepartments).EndInit();
            ((System.ComponentModel.ISupportInitialize)userDepartmentBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUserDepartments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancel;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewLogs;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMetaData;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditEmail;
        private DevExpress.XtraEditors.TextEdit textEditPhone;
        private DevExpress.XtraEditors.TextEdit textEditSurname;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.TextEdit textEditUsername;
        private DevExpress.XtraEditors.DateEdit dateEditExpiredAt;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageUserGroups;
        private DevExpress.XtraEditors.GroupControl groupControlUserGroups;
        private DevExpress.XtraGrid.GridControl gridControlUserGroups;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUserGroups;
        private DevExpress.XtraEditors.GroupControl groupControlAddGroups;
        private System.Windows.Forms.BindingSource userGroupBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraEditors.TokenEdit tokenEditGroups;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDepartments;
        private DevExpress.XtraEditors.GroupControl groupControlDepartments;
        private DevExpress.XtraGrid.GridControl gridControlUserDepartments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUserDepartments;
        private System.Windows.Forms.BindingSource userDepartmentBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colPlant;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colAppellation;
        private DevExpress.XtraGrid.Columns.GridColumn colStartFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colEndAt;
        private DevExpress.XtraGrid.Columns.GridColumn colDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
    }
}