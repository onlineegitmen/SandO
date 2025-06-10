using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static DevExpress.DataProcessing.InMemoryDataProcessor.AddSurrogateOperationAlgorithm;

namespace SandO.WinForms.Forms.Extras
{
    public partial class WaitFormMain : WaitForm
    {
        public WaitFormMain()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        public static void ShowWaitForm(string caption = "Lütfen bekleyiniz", string description = "Yükleniyor...")
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitFormMain));
            }
            catch (Exception)
            {
                SplashScreenManager.CloseForm(false);
                SplashScreenManager.ShowForm(typeof(WaitFormMain));
            }
            SplashScreenManager.Default.SetWaitFormCaption(caption);
            SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void CloseWaitForm()
        {
            SplashScreenManager.CloseForm(false);
        }
    }
}