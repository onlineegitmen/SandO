using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SandO.WinForms.Extensions;

public static class FormExtensions
{
    public static void SetEditableStatus(this XtraForm xtraForm, bool readOnly)
    {
        SetEditableStatus(xtraForm.Controls, readOnly);
    }

    private static void SetEditableStatus(Control.ControlCollection controls, bool readOnly)
    {
        foreach (Control control in controls)
        {
            if (control is TextEdit textEdit)
            {
                textEdit.ReadOnly = readOnly;
            }
            else if (control is CheckEdit checkEdit)
            {
                checkEdit.ReadOnly = readOnly;
            }

            if (control.HasChildren)
            {
                SetEditableStatus(control.Controls, readOnly);
            }
        }
    }
}