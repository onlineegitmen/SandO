namespace SandO.Entities.Enums;

public enum SystemSettingType
{
    TolerableTimeInSecond = 1,
    AdminGroupName = 2,
    AdminUsername = 3,
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this SystemSettingType me)
    {
        return me switch
        {
            SystemSettingType.TolerableTimeInSecond => "Saniye Cinsinden Tolere Edilebilir Süre",
            SystemSettingType.AdminGroupName => "Yönetici Grubu Adı",
            SystemSettingType.AdminUsername => "Yönetici Kullanıcı Adı",
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }

    public static ValueType SettingValueType(this SystemSettingType me)
    {
        return me switch
        {
            SystemSettingType.TolerableTimeInSecond => ValueType.Int,
            SystemSettingType.AdminGroupName => ValueType.String,
            SystemSettingType.AdminUsername => ValueType.String,
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }

    public static string DefaultValue(this SystemSettingType me)
    {
        return me switch
        {
            SystemSettingType.TolerableTimeInSecond => 10.ToString(),
            SystemSettingType.AdminGroupName => "Administrators",
            SystemSettingType.AdminUsername => "admin",
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }

    public static string Description(this SystemSettingType me)
    {
        return me switch
        {
            SystemSettingType.TolerableTimeInSecond =>
                "İstemci ile veri tabanı sunucusu arasındaki zaman farkının saniye cinsinden tolere edilebilir sınırını belirler.",
            SystemSettingType.AdminGroupName => "Yönetici grubunun adını belirler.",
            SystemSettingType.AdminUsername => "Yönetici kullanıcısının adını belirler.",
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }

    public static Module Module(this SystemSettingType me)
    {
        return me switch
        {
            SystemSettingType.TolerableTimeInSecond => Enums.Module.Admin,
            SystemSettingType.AdminGroupName => Enums.Module.Admin,
            SystemSettingType.AdminUsername => Enums.Module.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }

    public static bool IsEditable(this SystemSettingType me)
    {
        return me switch
        {
            SystemSettingType.TolerableTimeInSecond => true,
            SystemSettingType.AdminGroupName => false,
            SystemSettingType.AdminUsername => false,
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }
}