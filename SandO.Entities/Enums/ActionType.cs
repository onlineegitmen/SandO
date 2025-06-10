namespace SandO.Entities.Enums;

public enum ActionType
{
    Create = 1,
    Update = 2,
    Delete = 3,
    Restore = 4,
    PermissionChange = 5,
}

public static partial class EnumExtensions
{
    public static string GetDescription(this ActionType actionType)
    {
        return actionType switch
        {
            ActionType.Create => "Oluşturuldu",
            ActionType.Update => "Değiştirildi",
            ActionType.Delete => "Silindi",
            ActionType.Restore => "Yeniden Aktif Edildi",
            ActionType.PermissionChange => "İzin Değiştirildi",
            _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
        };
    }
}