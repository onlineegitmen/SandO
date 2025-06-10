namespace SandO.WinForms.Forms.UserGroup
{
    partial class XtraFormGroup
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
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemCancel = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemViewLogs = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemPermissions = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupProperties = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            comboBoxEditModule = new DevExpress.XtraEditors.ComboBoxEdit();
            textEditName = new DevExpress.XtraEditors.TextEdit();
            memoEditDesc = new DevExpress.XtraEditors.MemoEdit();
            checkEditDisableAllPermissions = new DevExpress.XtraEditors.CheckEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditModule.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEditDesc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEditDisableAllPermissions.Properties).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, barButtonItemSave, barButtonItemCancel, barButtonItemViewLogs, barButtonItemPermissions });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 6;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl.Size = new System.Drawing.Size(428, 150);
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
            // barButtonItemPermissions
            // 
            barButtonItemPermissions.Caption = "Yetkiler";
            barButtonItemPermissions.Id = 5;
            barButtonItemPermissions.ImageOptions.Image = Properties.Resources.bopermission_16x16;
            barButtonItemPermissions.ImageOptions.LargeImage = Properties.Resources.bopermission_32x32;
            barButtonItemPermissions.Name = "barButtonItemPermissions";
            barButtonItemPermissions.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            barButtonItemPermissions.ItemClick += barButtonItemPermissions_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroupProperties });
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
            // ribbonPageGroupProperties
            // 
            ribbonPageGroupProperties.ItemLinks.Add(barButtonItemPermissions);
            ribbonPageGroupProperties.Name = "ribbonPageGroupProperties";
            // 
            // comboBoxEditModule
            // 
            comboBoxEditModule.Location = new System.Drawing.Point(115, 156);
            comboBoxEditModule.MenuManager = ribbonControl;
            comboBoxEditModule.Name = "comboBoxEditModule";
            comboBoxEditModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditModule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxEditModule.Size = new System.Drawing.Size(285, 20);
            comboBoxEditModule.TabIndex = 1;
            // 
            // textEditName
            // 
            textEditName.Location = new System.Drawing.Point(115, 182);
            textEditName.MenuManager = ribbonControl;
            textEditName.Name = "textEditName";
            textEditName.Size = new System.Drawing.Size(285, 20);
            textEditName.TabIndex = 2;
            // 
            // memoEditDesc
            // 
            memoEditDesc.Location = new System.Drawing.Point(115, 208);
            memoEditDesc.MenuManager = ribbonControl;
            memoEditDesc.Name = "memoEditDesc";
            memoEditDesc.Size = new System.Drawing.Size(285, 96);
            memoEditDesc.TabIndex = 3;
            // 
            // checkEditDisableAllPermissions
            // 
            checkEditDisableAllPermissions.Location = new System.Drawing.Point(115, 310);
            checkEditDisableAllPermissions.MenuManager = ribbonControl;
            checkEditDisableAllPermissions.Name = "checkEditDisableAllPermissions";
            checkEditDisableAllPermissions.Properties.Caption = "Bütün Yetkileri Devredışı Bırak";
            checkEditDisableAllPermissions.Size = new System.Drawing.Size(193, 20);
            checkEditDisableAllPermissions.TabIndex = 4;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(12, 159);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(60, 13);
            labelControl1.TabIndex = 5;
            labelControl1.Text = "Grup Modülü";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(12, 185);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(41, 13);
            labelControl2.TabIndex = 5;
            labelControl2.Text = "Grup Adı";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(12, 210);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(41, 13);
            labelControl3.TabIndex = 5;
            labelControl3.Text = "Açıklama";
            // 
            // XtraFormGroup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(428, 354);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(checkEditDisableAllPermissions);
            Controls.Add(memoEditDesc);
            Controls.Add(textEditName);
            Controls.Add(comboBoxEditModule);
            Controls.Add(ribbonControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "XtraFormGroup";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Grup";
            Load += XtraFormTemp_Load;
            KeyDown += XtraFormTemp_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditModule.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEditDesc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEditDisableAllPermissions.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancel;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditModule;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.MemoEdit memoEditDesc;
        private DevExpress.XtraEditors.CheckEdit checkEditDisableAllPermissions;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewLogs;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupProperties;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPermissions;
    }
}