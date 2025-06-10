using System.ComponentModel;

namespace SandO.Entities.Enums;

public enum AuthenticationEvent
{
    [Description("Oluştur")]
    Create = 1,
    [Description("Oku")]
    Read = 2,
    [Description("Güncelle")]
    Update = 3,
    [Description("Sil")]
    Delete = 4,
    [Description("Kullanıcı/Grup Ata")]
    AssignUserOrGroup = 5,
    [Description("Yönetebilir")]
    CanManage = 6,
    [Description("İzinleri Ata")]
    AssignedPermissions = 7,
    [Description("Departmanları Ata")]
    AssignDepartmentsToUser = 8,
}

public class AuthenticationEventView(AuthenticationEvent authenticationEvent)
{
    public AuthenticationEvent AuthenticationEvent { get; set; } = authenticationEvent;
    public string Name => AuthenticationEvent.ToFriendlyString();
    public override string ToString()
    {
        return Name;
    }
    public static List<AuthenticationEventView> GetAuthenticationEventViews()
    {
        return Enum.GetValues<AuthenticationEvent>().Select(x => new AuthenticationEventView(x)).ToList();
    }
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this AuthenticationEvent me)
    {
        return me switch
        {
            AuthenticationEvent.Create => "Oluştur",
            AuthenticationEvent.Read => "Oku",
            AuthenticationEvent.Update => "Güncelle",
            AuthenticationEvent.Delete => "Sil",
            AuthenticationEvent.AssignUserOrGroup => "Kullanıcı/Grup Ata",
            AuthenticationEvent.CanManage => "Yönetebilir",
            AuthenticationEvent.AssignedPermissions => "İzinleri Ata",
            AuthenticationEvent.AssignDepartmentsToUser => "Kullanıcıya Departman Ata",
            _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
        };
    }
}