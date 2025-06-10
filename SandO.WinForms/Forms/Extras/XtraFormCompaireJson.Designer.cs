namespace SandO.WinForms.Forms.Extras
{
    partial class XtraFormCompaireJson
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
            gridControlValues = new DevExpress.XtraGrid.GridControl();
            logValueBindingSource = new System.Windows.Forms.BindingSource(components);
            gridViewValues = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPropertyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colOldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colNewValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlValues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logValueBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewValues).BeginInit();
            SuspendLayout();
            // 
            // gridControlValues
            // 
            gridControlValues.DataSource = logValueBindingSource;
            gridControlValues.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlValues.Location = new System.Drawing.Point(0, 0);
            gridControlValues.MainView = gridViewValues;
            gridControlValues.Name = "gridControlValues";
            gridControlValues.Size = new System.Drawing.Size(995, 767);
            gridControlValues.TabIndex = 0;
            gridControlValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewValues });
            // 
            // logValueBindingSource
            // 
            logValueBindingSource.DataSource = typeof(Entities.AppClasses.LogValue);
            // 
            // gridViewValues
            // 
            gridViewValues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPropertyDesc, colOldValue, colNewValue });
            gridViewValues.GridControl = gridControlValues;
            gridViewValues.Name = "gridViewValues";
            gridViewValues.OptionsBehavior.Editable = false;
            gridViewValues.OptionsCustomization.AllowColumnMoving = false;
            // 
            // colPropertyDesc
            // 
            colPropertyDesc.FieldName = "PropertyDesc";
            colPropertyDesc.Name = "colPropertyDesc";
            colPropertyDesc.Visible = true;
            colPropertyDesc.VisibleIndex = 0;
            // 
            // colOldValue
            // 
            colOldValue.FieldName = "OldValue";
            colOldValue.Name = "colOldValue";
            colOldValue.Visible = true;
            colOldValue.VisibleIndex = 1;
            // 
            // colNewValue
            // 
            colNewValue.FieldName = "NewValue";
            colNewValue.Name = "colNewValue";
            colNewValue.Visible = true;
            colNewValue.VisibleIndex = 2;
            // 
            // XtraFormCompaireJson
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(995, 767);
            Controls.Add(gridControlValues);
            Name = "XtraFormCompaireJson";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Değişiklik Karşılaştır";
            Load += XtraFormCompaireJson_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlValues).EndInit();
            ((System.ComponentModel.ISupportInitialize)logValueBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewValues).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewValues;
        private System.Windows.Forms.BindingSource logValueBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colOldValue;
        private DevExpress.XtraGrid.Columns.GridColumn colNewValue;
        private DevExpress.XtraGrid.Columns.GridColumn colPropertyDesc;
    }
}