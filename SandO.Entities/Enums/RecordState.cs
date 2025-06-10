namespace SandO.Entities.Enums;

public enum RecordState
{
    /// <summary>
    /// Indicates that the record state is not defined. This is the default value and should not be used.
    /// </summary>
    NotDefined = 0,
    /// <summary>
    /// Indicates that the record is active and can be used.
    /// </summary>
    Active = 1,
    /// <summary>
    /// Indicates that the record is passive and cannot be used.
    /// </summary>
    Passive = 2,
    /// <summary>
    /// Indicates that the record has been deleted and cannot be used.
    /// </summary>
    Deleted = 3,
    /// <summary>
    /// Indicates that the record is locked by an administrator and cannot be used.
    /// </summary>
    LockedByAdmin = 4,
    /// <summary>
    /// Indicates that the record is locked due to too many failed login attempts.
    /// </summary>
    LockedCauseMoreWrangPassword = 5,
}

public static partial class EnumExtensions
{
    public static string ToDescription(this RecordState value)
    {
        return value switch
        {
            RecordState.NotDefined => "Tanımsız",
            RecordState.Active => "Aktif",
            RecordState.Passive => "Pasif",
            RecordState.Deleted => "Silinmiş",
            RecordState.LockedByAdmin => "Yetkili Yönetici Tarafından Kilitlenmiş",
            RecordState.LockedCauseMoreWrangPassword => "Çok Fazla Yanlış Şifre Girişinden Kilitlenmiş",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}