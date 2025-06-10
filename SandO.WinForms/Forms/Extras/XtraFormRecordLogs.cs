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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SandO.Entities.Enums;

namespace SandO.WinForms.Forms.Extras
{
    public partial class XtraFormRecordLogs : XtraForm
    {
        public string RecordGuid { get; }
        public Type Type { get; }

        public XtraFormRecordLogs(string recordGuid, Type type)
        {
            InitializeComponent();
            RecordGuid = recordGuid;
            Type = type;
        }

        private void XtraFormRecordLogs_Load(object sender, EventArgs e)
        {
            QueryResult<List<LogView>> queryResult = NewtonJsonHelper.GetRecordLogs(RecordGuid);
            WaitFormMain.CloseWaitForm();

            if (queryResult.Result)
            {
                logViewBindingSource.DataSource = queryResult.ResultObject;
            }
            else
            {
                XtraMessageBox.Show(queryResult.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void gridControlRecordLogs_DoubleClick(object sender, EventArgs e)
        {
            LogView logView;
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                logView = info.RowInfo.RowKey as LogView;
                if (logView == null)
                {
                    return;
                }
            }
            else
            {
                return;
            }

            WaitFormMain.ShowWaitForm();
            XtraFormCompaireJson xtraFormCompaireJson = new XtraFormCompaireJson(logView.Id, Type);
            xtraFormCompaireJson.ShowDialog();
        }
    }
}