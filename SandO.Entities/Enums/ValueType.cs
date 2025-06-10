namespace SandO.Entities.Enums;

public enum ValueType
{
    Int,
    Decimal,
    String,
    Bool,
    Date,
    Time,
    DateTime
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this ValueType me)
    {
        switch (me)
        {
            case ValueType.Int:
                return "Tam Sayı";
            case ValueType.Decimal:
                return "Ondalıklı Sayı";
            case ValueType.String:
                return "Metin";
            case ValueType.Bool:
                return "Mantıksal";
            case ValueType.Date:
                return "Tarih";
            case ValueType.Time:
                return "Zaman";
            case ValueType.DateTime:
                return "Tarih ve Zaman";
            default:
                return "Unknown";
        }
    }
}