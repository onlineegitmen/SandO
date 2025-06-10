using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using SandO.Bll;

namespace SandO.WinForms.InitForms
{
    public partial class XtraFormDatabaseMigration : XtraForm
    {
        public XtraFormDatabaseMigration()
        {
            InitializeComponent();
        }

        private void simpleButtonCreateDatabase_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Veritabanı oluşturuluyor. Lütfen bekleyin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XtraMessageBox.Show(Bll.GlobalVariables.DatabaseConnectionInfo.ConnectionString);

            using SandOContext context = new SandOContext(Bll.GlobalVariables.DbContextOptions);
            context.Database.Migrate();

            XtraMessageBox.Show("Veritabanı oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}