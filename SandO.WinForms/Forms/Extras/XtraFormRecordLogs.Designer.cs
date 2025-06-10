namespace SandO.WinForms.Forms.Extras
{
    partial class XtraFormRecordLogs
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
            gridControlRecordLogs = new DevExpress.XtraGrid.GridControl();
            logViewBindingSource = new System.Windows.Forms.BindingSource(components);
            gridViewRecordLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colUserFullname = new DevExpress.XtraGrid.Columns.GridColumn();
            colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            colActionTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlRecordLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logViewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecordLogs).BeginInit();
            SuspendLayout();
            // 
            // gridControlRecordLogs
            // 
            gridControlRecordLogs.DataSource = logViewBindingSource;
            gridControlRecordLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlRecordLogs.Location = new System.Drawing.Point(0, 0);
            gridControlRecordLogs.MainView = gridViewRecordLogs;
            gridControlRecordLogs.Name = "gridControlRecordLogs";
            gridControlRecordLogs.Size = new System.Drawing.Size(698, 568);
            gridControlRecordLogs.TabIndex = 0;
            gridControlRecordLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewRecordLogs });
            // 
            // logViewBindingSource
            // 
            logViewBindingSource.DataSource = typeof(Entities.AppClasses.LogView);
            // 
            // gridViewRecordLogs
            // 
            gridViewRecordLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDateTime, colUserFullname, colUsername, colActionTypeName });
            gridViewRecordLogs.GridControl = gridControlRecordLogs;
            gridViewRecordLogs.Name = "gridViewRecordLogs";
            gridViewRecordLogs.OptionsBehavior.Editable = false;
            gridViewRecordLogs.OptionsCustomization.AllowSort = false;
            gridViewRecordLogs.DoubleClick += gridControlRecordLogs_DoubleClick;
            // 
            // colDateTime
            // 
            colDateTime.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            colDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDateTime.FieldName = "DateTime";
            colDateTime.Name = "colDateTime";
            colDateTime.Visible = true;
            colDateTime.VisibleIndex = 0;
            // 
            // colUserFullname
            // 
            colUserFullname.FieldName = "UserFullname";
            colUserFullname.Name = "colUserFullname";
            colUserFullname.Visible = true;
            colUserFullname.VisibleIndex = 1;
            // 
            // colUsername
            // 
            colUsername.FieldName = "Username";
            colUsername.Name = "colUsername";
            colUsername.Visible = true;
            colUsername.VisibleIndex = 2;
            // 
            // colActionTypeName
            // 
            colActionTypeName.FieldName = "ActionTypeName";
            colActionTypeName.Name = "colActionTypeName";
            colActionTypeName.OptionsColumn.ReadOnly = true;
            colActionTypeName.Visible = true;
            colActionTypeName.VisibleIndex = 3;
            // 
            // XtraFormRecordLogs
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(698, 568);
            Controls.Add(gridControlRecordLogs);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "XtraFormRecordLogs";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Değişiklik Belgeleri";
            Load += XtraFormRecordLogs_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlRecordLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)logViewBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecordLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlRecordLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecordLogs;
        private System.Windows.Forms.BindingSource logViewBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFullname;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colActionTypeName;
    }
}