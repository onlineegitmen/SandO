namespace SandO.WinForms.InitForms
{
    partial class XtraFormDatabaseMigration
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
            simpleButtonCreateDatabase = new DevExpress.XtraEditors.SimpleButton();
            SuspendLayout();
            // 
            // simpleButtonCreateDatabase
            // 
            simpleButtonCreateDatabase.Location = new System.Drawing.Point(398, 12);
            simpleButtonCreateDatabase.Name = "simpleButtonCreateDatabase";
            simpleButtonCreateDatabase.Size = new System.Drawing.Size(130, 23);
            simpleButtonCreateDatabase.TabIndex = 0;
            simpleButtonCreateDatabase.Text = "Veri Tabanını Güncelle";
            simpleButtonCreateDatabase.Click += simpleButtonCreateDatabase_Click;
            // 
            // XtraFormDatabaseMigration
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(540, 442);
            Controls.Add(simpleButtonCreateDatabase);
            Name = "XtraFormDatabaseMigration";
            Text = "XtraFormDatabaseMigration";
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonCreateDatabase;
    }
}