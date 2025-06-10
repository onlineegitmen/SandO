namespace SandO.WinForms.Forms.Organization
{
    partial class XtraFormCompany
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
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            textEditCompanyCode = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            textEditCompanyName = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEditTaxOffice = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            textEditTaxNumber = new DevExpress.XtraEditors.TextEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            textEditTradeRegistryNumber = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditCompanyCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditCompanyName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditTaxOffice.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditTaxNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditTradeRegistryNumber.Properties).BeginInit();
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
            ribbonControl.Size = new System.Drawing.Size(427, 150);
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
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(12, 159);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(54, 13);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Şirket Kodu";
            // 
            // textEditCompanyCode
            // 
            textEditCompanyCode.Location = new System.Drawing.Point(102, 156);
            textEditCompanyCode.MenuManager = ribbonControl;
            textEditCompanyCode.Name = "textEditCompanyCode";
            textEditCompanyCode.Size = new System.Drawing.Size(100, 20);
            textEditCompanyCode.TabIndex = 0;
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(12, 185);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(45, 13);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Şirket Adı";
            // 
            // textEditCompanyName
            // 
            textEditCompanyName.Location = new System.Drawing.Point(102, 182);
            textEditCompanyName.Name = "textEditCompanyName";
            textEditCompanyName.Size = new System.Drawing.Size(293, 20);
            textEditCompanyName.TabIndex = 1;
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(12, 211);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(59, 13);
            labelControl3.TabIndex = 1;
            labelControl3.Text = "Vergi Dairesi";
            // 
            // textEditTaxOffice
            // 
            textEditTaxOffice.Location = new System.Drawing.Point(102, 208);
            textEditTaxOffice.Name = "textEditTaxOffice";
            textEditTaxOffice.Size = new System.Drawing.Size(293, 20);
            textEditTaxOffice.TabIndex = 2;
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(12, 237);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(71, 13);
            labelControl4.TabIndex = 1;
            labelControl4.Text = "Vergi Numarası";
            // 
            // textEditTaxNumber
            // 
            textEditTaxNumber.Location = new System.Drawing.Point(102, 234);
            textEditTaxNumber.Name = "textEditTaxNumber";
            textEditTaxNumber.Size = new System.Drawing.Size(293, 20);
            textEditTaxNumber.TabIndex = 3;
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(12, 263);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(84, 13);
            labelControl5.TabIndex = 1;
            labelControl5.Text = "Tic. Sicil Numarası";
            // 
            // textEditTradeRegistryNumber
            // 
            textEditTradeRegistryNumber.Location = new System.Drawing.Point(102, 260);
            textEditTradeRegistryNumber.Name = "textEditTradeRegistryNumber";
            textEditTradeRegistryNumber.Size = new System.Drawing.Size(293, 20);
            textEditTradeRegistryNumber.TabIndex = 4;
            // 
            // XtraFormCompany
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(427, 295);
            Controls.Add(textEditTradeRegistryNumber);
            Controls.Add(labelControl5);
            Controls.Add(textEditTaxNumber);
            Controls.Add(labelControl4);
            Controls.Add(textEditTaxOffice);
            Controls.Add(labelControl3);
            Controls.Add(textEditCompanyName);
            Controls.Add(labelControl2);
            Controls.Add(textEditCompanyCode);
            Controls.Add(labelControl1);
            Controls.Add(ribbonControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "XtraFormCompany";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Şirket";
            Load += XtraFormTemp_Load;
            KeyDown += XtraFormTemp_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditCompanyCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditCompanyName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditTaxOffice.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditTaxNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditTradeRegistryNumber.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditCompanyCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditCompanyName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEditTaxOffice;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditTaxNumber;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEditTradeRegistryNumber;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewLogs;
    }
}