using System.Drawing;
using System.Windows.Forms;

namespace SandO.WinForms.Enums;

public enum MessageType
{
    Error,
    Information,
    Warning
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this MessageType messageType)
    {
        switch (messageType)
        {
            case MessageType.Error:
                return "Hata";
            case MessageType.Information:
                return "Bilgilendirme";
            case MessageType.Warning:
                return "Uyarı";
            default:
                return string.Empty;
        }
    }

    public static MessageBoxIcon GetIcon(this MessageType messageType)
    {
        switch (messageType)
        {
            case MessageType.Error:
                return MessageBoxIcon.Error;
            case MessageType.Information:
                return MessageBoxIcon.Information;
            case MessageType.Warning:
                return MessageBoxIcon.Warning;
            default:
                return MessageBoxIcon.None;
        }
    }

    public static Color GetColor(this MessageType messageType)
    {
        switch (messageType)
        {
            case MessageType.Error:
                return Color.OrangeRed;
            case MessageType.Information:
                return Color.ForestGreen;
            case MessageType.Warning:
                return Color.Yellow;
            default:
                return Color.Black;
        }
    }
}