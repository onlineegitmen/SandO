namespace SandO.WinForms.Forms.Organization
{
    partial class XtraFormPlant
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
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            comboBoxEditCompanies = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEditCode = new DevExpress.XtraEditors.TextEdit();
            textEditName = new DevExpress.XtraEditors.TextEdit();
            barButtonItemViewLogs = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditCompanies.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditName.Properties).BeginInit();
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
            ribbonControl.Size = new System.Drawing.Size(419, 150);
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
            // comboBoxEditCompanies
            // 
            comboBoxEditCompanies.Location = new System.Drawing.Point(95, 156);
            comboBoxEditCompanies.MenuManager = ribbonControl;
            comboBoxEditCompanies.Name = "comboBoxEditCompanies";
            comboBoxEditCompanies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditCompanies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxEditCompanies.Size = new System.Drawing.Size(271, 20);
            comboBoxEditCompanies.TabIndex = 0;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(12, 159);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(27, 13);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Şirket";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(12, 185);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(24, 13);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Kodu";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(12, 211);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(15, 13);
            labelControl3.TabIndex = 4;
            labelControl3.Text = "Adı";
            // 
            // textEditCode
            // 
            textEditCode.Location = new System.Drawing.Point(95, 182);
            textEditCode.MenuManager = ribbonControl;
            textEditCode.Name = "textEditCode";
            textEditCode.Size = new System.Drawing.Size(100, 20);
            textEditCode.TabIndex = 1;
            // 
            // textEditName
            // 
            textEditName.Location = new System.Drawing.Point(95, 208);
            textEditName.Name = "textEditName";
            textEditName.Size = new System.Drawing.Size(271, 20);
            textEditName.TabIndex = 2;
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
            // XtraFormPlant
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(419, 273);
            Controls.Add(textEditName);
            Controls.Add(textEditCode);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(comboBoxEditCompanies);
            Controls.Add(ribbonControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "XtraFormPlant";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "XtraFormGroupPermissions";
            Load += XtraFormTemp_Load;
            KeyDown += XtraFormTemp_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditCompanies.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditName.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancel;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditCompanies;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEditCode;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewLogs;
    }
}