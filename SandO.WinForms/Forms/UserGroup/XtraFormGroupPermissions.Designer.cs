namespace SandO.WinForms.Forms.UserGroup
{
    partial class XtraFormGroupPermissions
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
            groupControlPerClass = new DevExpress.XtraEditors.GroupControl();
            listBoxControlAuthClass = new DevExpress.XtraEditors.ListBoxControl();
            groupControlPerEvent = new DevExpress.XtraEditors.GroupControl();
            checkedListBoxControlAuthEvent = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPerClass).BeginInit();
            groupControlPerClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listBoxControlAuthClass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPerEvent).BeginInit();
            groupControlPerEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkedListBoxControlAuthEvent).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, barButtonItemSave, barButtonItemCancel });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 5;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl.Size = new System.Drawing.Size(380, 150);
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
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // groupControlPerClass
            // 
            groupControlPerClass.Controls.Add(listBoxControlAuthClass);
            groupControlPerClass.Dock = System.Windows.Forms.DockStyle.Top;
            groupControlPerClass.Location = new System.Drawing.Point(0, 150);
            groupControlPerClass.Name = "groupControlPerClass";
            groupControlPerClass.Size = new System.Drawing.Size(380, 167);
            groupControlPerClass.TabIndex = 1;
            groupControlPerClass.Text = "Yetki Sınıfı";
            // 
            // listBoxControlAuthClass
            // 
            listBoxControlAuthClass.Dock = System.Windows.Forms.DockStyle.Fill;
            listBoxControlAuthClass.Location = new System.Drawing.Point(2, 23);
            listBoxControlAuthClass.Name = "listBoxControlAuthClass";
            listBoxControlAuthClass.Size = new System.Drawing.Size(376, 142);
            listBoxControlAuthClass.TabIndex = 0;
            listBoxControlAuthClass.SelectedIndexChanged += listBoxControlAuthClass_SelectedIndexChanged;
            // 
            // groupControlPerEvent
            // 
            groupControlPerEvent.Controls.Add(checkedListBoxControlAuthEvent);
            groupControlPerEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControlPerEvent.Location = new System.Drawing.Point(0, 317);
            groupControlPerEvent.Name = "groupControlPerEvent";
            groupControlPerEvent.Size = new System.Drawing.Size(380, 218);
            groupControlPerEvent.TabIndex = 2;
            groupControlPerEvent.Text = "Yetki";
            // 
            // checkedListBoxControlAuthEvent
            // 
            checkedListBoxControlAuthEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            checkedListBoxControlAuthEvent.Location = new System.Drawing.Point(2, 23);
            checkedListBoxControlAuthEvent.Name = "checkedListBoxControlAuthEvent";
            checkedListBoxControlAuthEvent.Size = new System.Drawing.Size(376, 193);
            checkedListBoxControlAuthEvent.TabIndex = 0;
            checkedListBoxControlAuthEvent.ItemCheck += checkedListBoxControlAuthEvent_ItemCheck;
            // 
            // XtraFormGroupPermissions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(380, 535);
            Controls.Add(groupControlPerEvent);
            Controls.Add(groupControlPerClass);
            Controls.Add(ribbonControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "XtraFormGroupPermissions";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Grup Yetkileri";
            Load += XtraFormTemp_Load;
            KeyDown += XtraFormTemp_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPerClass).EndInit();
            groupControlPerClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listBoxControlAuthClass).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPerEvent).EndInit();
            groupControlPerEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)checkedListBoxControlAuthEvent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCancel;
        private DevExpress.XtraEditors.GroupControl groupControlPerClass;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlAuthClass;
        private DevExpress.XtraEditors.GroupControl groupControlPerEvent;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControlAuthEvent;
    }
}