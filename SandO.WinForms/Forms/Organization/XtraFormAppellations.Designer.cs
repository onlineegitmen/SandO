using SandO.Entities.Db;

namespace SandO.WinForms.Forms.Organization
{
    partial class XtraFormAppellations
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
            colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            colRecordStateName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            bindingSource.DataSource = typeof(Appellation);
            // 
            // gridViewMain
            // 
            gridViewMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCode, colName, colDescription, colGuid, colRecordStateName });
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
            // colCode
            // 
            colCode.FieldName = "Code";
            colCode.Name = "colCode";
            colCode.Visible = true;
            colCode.VisibleIndex = 0;
            // 
            // colName
            // 
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 1;
            // 
            // colDescription
            // 
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 2;
            // 
            // colGuid
            // 
            colGuid.FieldName = "Guid";
            colGuid.Name = "colGuid";
            colGuid.Visible = true;
            colGuid.VisibleIndex = 3;
            // 
            // colRecordStateName
            // 
            colRecordStateName.FieldName = "RecordStateName";
            colRecordStateName.Name = "colRecordStateName";
            colRecordStateName.OptionsColumn.ReadOnly = true;
            colRecordStateName.Visible = true;
            colRecordStateName.VisibleIndex = 4;
            // 
            // XtraFormAppellations
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(819, 654);
            Controls.Add(gridControlMain);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl);
            KeyPreview = true;
            Name = "XtraFormAppellations";
            Text = "Ünvanlar";
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
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordStateName;
    }
}