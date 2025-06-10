using System.Drawing;
using DevExpress.XtraBars.Ribbon;
using System.Windows.Controls.Ribbon;
using System.Windows.Forms;
using DevExpress.Utils;
using SandO.WinForms.Enums;
using RibbonControl = DevExpress.XtraBars.Ribbon.RibbonControl;

namespace SandO.WinForms.Extensions;

public static class RibbonControlExtensions
{
    public static void SetRibbonStyle(this RibbonControl ribbonControl)
    {
        ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.ShowOnMultiplePages;
        ribbonControl.ShowApplicationButton = DefaultBoolean.False;
        ribbonControl.ShowToolbarCustomizeItem = false;
        ribbonControl.ShowExpandCollapseButton = DefaultBoolean.False;
    }

    public static void SetMessage(this RibbonControl ribbonControl, string message, MessageType messageType)
    {
        ribbonControl.Messages.Clear();

        RibbonMessageArgs args = new RibbonMessageArgs
        {
            Caption = messageType.ToFriendlyString(),
            Text = message,
            Icon = messageType.GetIcon(),
            Buttons = [DialogResult.OK],
            Color = messageType.GetColor()
        };
        ribbonControl.ShowMessage(args);
    }
}