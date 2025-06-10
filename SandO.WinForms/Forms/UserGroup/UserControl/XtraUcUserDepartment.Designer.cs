namespace SandO.WinForms.Forms.UserGroup.UserControl
{
    partial class XtraUcUserDepartment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxEditCompanies = new DevExpress.XtraEditors.ComboBoxEdit();
            comboBoxEditPlants = new DevExpress.XtraEditors.ComboBoxEdit();
            comboBoxEditDepartments = new DevExpress.XtraEditors.ComboBoxEdit();
            comboBoxEditAppelations = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditCompanies.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditPlants.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditDepartments.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditAppelations.Properties).BeginInit();
            SuspendLayout();
            // 
            // comboBoxEditCompanies
            // 
            comboBoxEditCompanies.Location = new System.Drawing.Point(68, 3);
            comboBoxEditCompanies.Name = "comboBoxEditCompanies";
            comboBoxEditCompanies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditCompanies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxEditCompanies.Size = new System.Drawing.Size(273, 20);
            comboBoxEditCompanies.TabIndex = 0;
            comboBoxEditCompanies.SelectedIndexChanged += comboBoxEditCompanies_SelectedIndexChanged;
            // 
            // comboBoxEditPlants
            // 
            comboBoxEditPlants.Location = new System.Drawing.Point(68, 29);
            comboBoxEditPlants.Name = "comboBoxEditPlants";
            comboBoxEditPlants.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditPlants.Size = new System.Drawing.Size(273, 20);
            comboBoxEditPlants.TabIndex = 0;
            // 
            // comboBoxEditDepartments
            // 
            comboBoxEditDepartments.Location = new System.Drawing.Point(68, 55);
            comboBoxEditDepartments.Name = "comboBoxEditDepartments";
            comboBoxEditDepartments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditDepartments.Size = new System.Drawing.Size(273, 20);
            comboBoxEditDepartments.TabIndex = 0;
            // 
            // comboBoxEditAppelations
            // 
            comboBoxEditAppelations.Location = new System.Drawing.Point(68, 81);
            comboBoxEditAppelations.Name = "comboBoxEditAppelations";
            comboBoxEditAppelations.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditAppelations.Size = new System.Drawing.Size(273, 20);
            comboBoxEditAppelations.TabIndex = 0;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(3, 6);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(27, 13);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Şirket";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(3, 32);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(52, 13);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Üretim Yeri";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(3, 58);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(53, 13);
            labelControl3.TabIndex = 1;
            labelControl3.Text = "Departman";
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(3, 84);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(31, 13);
            labelControl4.TabIndex = 1;
            labelControl4.Text = "Ünvan";
            // 
            // XtraUcUserDepartment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(labelControl2);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(labelControl1);
            Controls.Add(comboBoxEditAppelations);
            Controls.Add(comboBoxEditPlants);
            Controls.Add(comboBoxEditDepartments);
            Controls.Add(comboBoxEditCompanies);
            Name = "XtraUcUserDepartment";
            Size = new System.Drawing.Size(362, 125);
            Load += XtraUcUserDepartment_Load;
            ((System.ComponentModel.ISupportInitialize)comboBoxEditCompanies.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditPlants.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditDepartments.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditAppelations.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditCompanies;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditPlants;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditDepartments;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditAppelations;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
