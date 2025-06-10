using SandO.Entities.AppClasses;

namespace SandO.WinForms.Forms.UserGroup
{
    partial class XtraFormUsers
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
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemView = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemExport = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupCurrentRow = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupNew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupList = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            gridControlMain = new DevExpress.XtraGrid.GridControl();
            bindingSource = new System.Windows.Forms.BindingSource(components);
            gridViewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            popupMenu = new DevExpress.XtraBars.PopupMenu(components);
            colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            colFirstname = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastname = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastPasswordSetDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastLoginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colExpiredAt = new DevExpress.XtraGrid.Columns.GridColumn();
            colFullname = new DevExpress.XtraGrid.Columns.GridColumn();
            colRecordStateDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            colEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, barButtonItemNew, barButtonItemUpdate, barButtonItemView, barButtonItemDelete, barButtonItemRefresh, barButtonItemExport });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 7;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl.Size = new System.Drawing.Size(819, 150);
            ribbonControl.StatusBar = ribbonStatusBar1;
            // 
            // barButtonItemNew
            // 
            barButtonItemNew.Caption = "Yeni";
            barButtonItemNew.Id = 1;
            barButtonItemNew.ImageOptions.Image = Properties.Resources.new_16x16;
            barButtonItemNew.ImageOptions.LargeImage = Properties.Resources.new_32x32;
            barButtonItemNew.Name = "barButtonItemNew";
            barButtonItemNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemNew.ItemClick += barButtonItemNew_ItemClick;
            // 
            // barButtonItemUpdate
            // 
            barButtonItemUpdate.Caption = "Düzenle";
            barButtonItemUpdate.Id = 2;
            barButtonItemUpdate.ImageOptions.Image = Properties.Resources.edit_16x16;
            barButtonItemUpdate.ImageOptions.LargeImage = Properties.Resources.edit_32x32;
            barButtonItemUpdate.Name = "barButtonItemUpdate";
            barButtonItemUpdate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemUpdate.ItemClick += barButtonItemUpdate_ItemClick;
            // 
            // barButtonItemView
            // 
            barButtonItemView.Caption = "Görüntüle";
            barButtonItemView.Id = 3;
            barButtonItemView.ImageOptions.Image = Properties.Resources.zoom_16x16;
            barButtonItemView.ImageOptions.LargeImage = Properties.Resources.zoom_32x32;
            barButtonItemView.Name = "barButtonItemView";
            barButtonItemView.ItemClick += barButtonItemView_ItemClick;
            // 
            // barButtonItemDelete
            // 
            barButtonItemDelete.Caption = "Sil";
            barButtonItemDelete.Id = 4;
            barButtonItemDelete.ImageOptions.Image = Properties.Resources.deletelist_16x16;
            barButtonItemDelete.ImageOptions.LargeImage = Properties.Resources.deletelist_32x32;
            barButtonItemDelete.Name = "barButtonItemDelete";
            barButtonItemDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemDelete.ItemClick += barButtonItemDelete_ItemClick;
            // 
            // barButtonItemRefresh
            // 
            barButtonItemRefresh.Caption = "Yenile";
            barButtonItemRefresh.Id = 5;
            barButtonItemRefresh.ImageOptions.Image = Properties.Resources.refresh2_16x16;
            barButtonItemRefresh.ImageOptions.LargeImage = Properties.Resources.refresh2_32x32;
            barButtonItemRefresh.Name = "barButtonItemRefresh";
            barButtonItemRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemRefresh.ItemClick += barButtonItemRefresh_ItemClick;
            // 
            // barButtonItemExport
            // 
            barButtonItemExport.Caption = "Dışa Aktar";
            barButtonItemExport.Id = 6;
            barButtonItemExport.ImageOptions.Image = Properties.Resources.export_16x16;
            barButtonItemExport.ImageOptions.LargeImage = Properties.Resources.export_32x32;
            barButtonItemExport.Name = "barButtonItemExport";
            barButtonItemExport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            barButtonItemExport.ItemClick += barButtonItemExport_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupCurrentRow, ribbonPageGroupNew, ribbonPageGroupList });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroupCurrentRow
            // 
            ribbonPageGroupCurrentRow.ItemLinks.Add(barButtonItemView);
            ribbonPageGroupCurrentRow.ItemLinks.Add(barButtonItemUpdate);
            ribbonPageGroupCurrentRow.ItemLinks.Add(barButtonItemDelete);
            ribbonPageGroupCurrentRow.Name = "ribbonPageGroupCurrentRow";
            ribbonPageGroupCurrentRow.Text = "Seçili Satır İşlemleri";
            // 
            // ribbonPageGroupNew
            // 
            ribbonPageGroupNew.ItemLinks.Add(barButtonItemNew);
            ribbonPageGroupNew.Name = "ribbonPageGroupNew";
            // 
            // ribbonPageGroupList
            // 
            ribbonPageGroupList.ItemLinks.Add(barButtonItemRefresh);
            ribbonPageGroupList.ItemLinks.Add(barButtonItemExport);
            ribbonPageGroupList.Name = "ribbonPageGroupList";
            ribbonPageGroupList.Text = "Liste İşlemleri";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 627);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl;
            ribbonStatusBar1.Size = new System.Drawing.Size(819, 27);
            // 
            // gridControlMain
            // 
            gridControlMain.DataSource = bindingSource;
            gridControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlMain.Location = new System.Drawing.Point(0, 150);
            gridControlMain.MainView = gridViewMain;
            gridControlMain.MenuManager = ribbonControl;
            gridControlMain.Name = "gridControlMain";
            gridControlMain.Size = new System.Drawing.Size(819, 477);
            gridControlMain.TabIndex = 2;
            gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewMain });
            gridControlMain.MouseClick += gridControlMain_MouseClick;
            // 
            // bindingSource
            // 
            bindingSource.DataSource = typeof(UserView);
            // 
            // gridViewMain
            // 
            gridViewMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colUsername, colFirstname, colLastname, colLastPasswordSetDate, colLastLoginDate, colExpiredAt, colFullname, colRecordStateDescription, colGuid, colEMail, colPhone });
            gridViewMain.GridControl = gridControlMain;
            gridViewMain.Name = "gridViewMain";
            gridViewMain.OptionsBehavior.Editable = false;
            gridViewMain.OptionsView.ShowGroupPanel = false;
            gridViewMain.OptionsView.ShowViewCaption = true;
            gridViewMain.ViewCaption = "Kayıtlar";
            // 
            // popupMenu
            // 
            popupMenu.ItemLinks.Add(barButtonItemView);
            popupMenu.ItemLinks.Add(barButtonItemUpdate);
            popupMenu.Name = "popupMenu";
            popupMenu.Ribbon = ribbonControl;
            // 
            // colUsername
            // 
            colUsername.FieldName = "Username";
            colUsername.Name = "colUsername";
            colUsername.Visible = true;
            colUsername.VisibleIndex = 0;
            // 
            // colFirstname
            // 
            colFirstname.FieldName = "Firstname";
            colFirstname.Name = "colFirstname";
            colFirstname.Visible = true;
            colFirstname.VisibleIndex = 1;
            // 
            // colLastname
            // 
            colLastname.FieldName = "Lastname";
            colLastname.Name = "colLastname";
            colLastname.Visible = true;
            colLastname.VisibleIndex = 2;
            // 
            // colLastPasswordSetDate
            // 
            colLastPasswordSetDate.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            colLastPasswordSetDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colLastPasswordSetDate.FieldName = "LastPasswordSetDate";
            colLastPasswordSetDate.Name = "colLastPasswordSetDate";
            colLastPasswordSetDate.Visible = true;
            colLastPasswordSetDate.VisibleIndex = 3;
            // 
            // colLastLoginDate
            // 
            colLastLoginDate.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            colLastLoginDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colLastLoginDate.FieldName = "LastLoginDate";
            colLastLoginDate.Name = "colLastLoginDate";
            colLastLoginDate.Visible = true;
            colLastLoginDate.VisibleIndex = 4;
            // 
            // colExpiredAt
            // 
            colExpiredAt.DisplayFormat.FormatString = "dd.MM.yyyy";
            colExpiredAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colExpiredAt.FieldName = "ExpiredAt";
            colExpiredAt.Name = "colExpiredAt";
            colExpiredAt.Visible = true;
            colExpiredAt.VisibleIndex = 5;
            // 
            // colFullname
            // 
            colFullname.FieldName = "Fullname";
            colFullname.Name = "colFullname";
            colFullname.OptionsColumn.ReadOnly = true;
            colFullname.Visible = true;
            colFullname.VisibleIndex = 6;
            // 
            // colRecordStateDescription
            // 
            colRecordStateDescription.FieldName = "RecordStateDescription";
            colRecordStateDescription.Name = "colRecordStateDescription";
            colRecordStateDescription.OptionsColumn.ReadOnly = true;
            colRecordStateDescription.Visible = true;
            colRecordStateDescription.VisibleIndex = 7;
            // 
            // colGuid
            // 
            colGuid.FieldName = "Guid";
            colGuid.Name = "colGuid";
            colGuid.Visible = true;
            colGuid.VisibleIndex = 8;
            // 
            // colEMail
            // 
            colEMail.FieldName = "EMail";
            colEMail.Name = "colEMail";
            colEMail.Visible = true;
            colEMail.VisibleIndex = 9;
            // 
            // colPhone
            // 
            colPhone.FieldName = "Phone";
            colPhone.Name = "colPhone";
            colPhone.Visible = true;
            colPhone.VisibleIndex = 10;
            // 
            // XtraFormUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(819, 654);
            Controls.Add(gridControlMain);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl);
            KeyPreview = true;
            Name = "XtraFormUsers";
            Text = "Kullanıcılar";
            FormClosing += XtraFormTemps_FormClosing;
            Load += XtraFormTemps_Load;
            KeyDown += XtraFormTemps_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupCurrentRow;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        private DevExpress.XtraBars.BarButtonItem barButtonItemView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupList;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExport;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstname;
        private DevExpress.XtraGrid.Columns.GridColumn colLastname;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPasswordSetDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastLoginDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiredAt;
        private DevExpress.XtraGrid.Columns.GridColumn colFullname;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordStateDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraGrid.Columns.GridColumn colEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
    }
}