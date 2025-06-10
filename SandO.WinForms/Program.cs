using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using SandO.WinForms.Enums;
using SandO.WinForms.MainForm;
using SandO.WinForms.Templates;
using Microsoft.Extensions.Configuration;
using System.IO;
using SandO.WinForms.InitForms;

namespace SandO.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            if (!GetDbConnectionInfo())
            {
                return;
            }

            LoggedInState loggedInState = LogIn();

            if (loggedInState == LoggedInState.LoggedIn)
            {
                Application.Run(new XtraFormMain());
            }
        }

        private static bool GetDbConnectionInfo()
        {
            // `appsettings.json`'u yükle
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Connection String'i oku
            string connectionString = config.GetConnectionString("DefaultConnection");

            if (connectionString == null)
            {
                return false;
            }

            Bll.GlobalVariables.DatabaseConnectionInfo = new Bll.BllClasses.DatabaseConnectionInfo(connectionString, Entities.Enums.DatabaseType.MsSql);

            return true;
        }

        private static LoggedInState LogIn()
        {
            Bll.GlobalVariables.LoggedInUser = new Entities.AppClasses.UserView
            {
                Id = Environment.MachineName == "MBT02" ? 2 : 4,
            };

            return LoggedInState.LoggedIn;
        }
    }
}
