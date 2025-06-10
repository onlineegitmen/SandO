using System.Windows.Forms;
using DevExpress.XtraEditors;
using SandO.Entities.AppClasses;

namespace SandO.WinForms.Extensions;

public static class ProgressResultExtensions
{
    public static void Show(this ProgressResult progressResult)
    {
        if (progressResult == null)
        {
            return;
        }

        XtraMessageBox.Show(progressResult.Message, progressResult.Result ? "Başarılı" : "Hata", MessageBoxButtons.OK, progressResult.Result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
    }
}