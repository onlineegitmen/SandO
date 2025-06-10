using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SandO.Bll.Helpers;
using SandO.Entities.AppClasses;
using SandO.Entities.Enums;

namespace SandO.WinForms.Forms.Extras
{
    public partial class XtraFormCompaireJson : XtraForm
    {
        public int LogId { get; }
        public Type TableType { get; }

        public XtraFormCompaireJson(int logId, Type tableType)
        {
            InitializeComponent();
            LogId = logId;
            TableType = tableType;
        }

        private void XtraFormCompaireJson_Load(object sender, EventArgs e)
        {
            QueryResult<List<LogValue>> values = NewtonJsonHelper.GetLogJsons(LogId, TableType);
            WaitFormMain.CloseWaitForm();
            if (values.Result)
            {
                logValueBindingSource.DataSource = values.ResultObject;
            }
            else
            {
                XtraMessageBox.Show("Kayıt bulunamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }
    }
}