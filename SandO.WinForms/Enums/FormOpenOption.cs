using System;

namespace SandO.WinForms.Enums;

public enum FormOpenOption
{
    Create,
    Update,
    View
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this FormOpenOption formOpenOption)
    {
        switch (formOpenOption)
        {
            case FormOpenOption.Create:
                return "Yeni";
            case FormOpenOption.Update:
                return "Güncelle";
            case FormOpenOption.View:
                return "Görüntüle";
            default:
                return string.Empty;
        }
    }

    public static bool IsReadOnly(this FormOpenOption formOpenOption)
    {
        switch (formOpenOption)
        {
            case FormOpenOption.Create:
                return false;
                break;
            case FormOpenOption.Update:
                return false;
                break;
            case FormOpenOption.View:
                return true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(formOpenOption), formOpenOption, null);
        }
    }
}