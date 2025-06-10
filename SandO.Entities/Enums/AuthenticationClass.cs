using System.ComponentModel;

namespace SandO.Entities.Enums;

public enum AuthenticationClass
{
    [Description("Kullanıcı / Grup")]
    UserGroup = 1,
    [Description("Sunucu Ayarları")]
    ServerSettings = 2,
    [Description("Şirket")]
    Company = 3,
    [Description("Üretim Yeri")]
    Plant = 4,
    [Description("Departman")]
    Department = 5,
    [Description("Ünvan")]
    Appellation = 6,
}

public class AuthenticationClassView(AuthenticationClass authenticationClass)
{
    public AuthenticationClass AuthenticationClass { get; set; } = authenticationClass;
    public string Name => AuthenticationClass.ToFriendlyString();
    public bool NeedParameter => AuthenticationClass.IsNeedParameter();

    public override string ToString()
    {
        return Name;
    }

    public static List<AuthenticationClassView> GetAuthenticationClassViews()
    {
        return Enum.GetValues<AuthenticationClass>().Select(x => new AuthenticationClassView(x)).ToList();
    }
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this AuthenticationClass me)
    {
        switch (me)
        {
            case AuthenticationClass.UserGroup:
                return "Kullanıcı / Grup";
            case AuthenticationClass.ServerSettings:
                return "Sunucu Ayarları";
            case AuthenticationClass.Company:
                return "Şirket";
            case AuthenticationClass.Plant:
                return "Üretim Yeri";
            case AuthenticationClass.Department:
                return "Departman";
            case AuthenticationClass.Appellation:
                return "Ünvan";
            default:
                throw new ArgumentOutOfRangeException(nameof(me), me, null);
        }
    }

    public static Tuple<List<AuthenticationEvent>, List<AuthenticationEventView>> GetAuthenticationEventViews(this AuthenticationClass authenticationClass)
    {
        List<AuthenticationEvent> authenticationEvents;

        switch (authenticationClass)
        {
            case AuthenticationClass.UserGroup:
                authenticationEvents =
                [
                    AuthenticationEvent.Create,
                    AuthenticationEvent.Read,
                    AuthenticationEvent.Update,
                    AuthenticationEvent.Delete,
                    AuthenticationEvent.AssignUserOrGroup,
                    AuthenticationEvent.CanManage,
                    AuthenticationEvent.AssignedPermissions,
                    AuthenticationEvent.AssignDepartmentsToUser
                ];
                break;
            case AuthenticationClass.ServerSettings:
                authenticationEvents =
                [
                    AuthenticationEvent.Read,
                    AuthenticationEvent.Update
                ];
                break;
            case AuthenticationClass.Company:
                authenticationEvents =
                [
                    AuthenticationEvent.Create,
                    AuthenticationEvent.Read,
                    AuthenticationEvent.Update,
                    AuthenticationEvent.Delete,
                    AuthenticationEvent.CanManage
                ];
                break;
            case AuthenticationClass.Plant:
                authenticationEvents =
                [
                    AuthenticationEvent.Create,
                    AuthenticationEvent.Read,
                    AuthenticationEvent.Update,
                    AuthenticationEvent.Delete,
                    AuthenticationEvent.CanManage
                ];
                break;
            case AuthenticationClass.Department:
                authenticationEvents =
                [
                    AuthenticationEvent.Create,
                    AuthenticationEvent.Read,
                    AuthenticationEvent.Update,
                    AuthenticationEvent.Delete,
                    AuthenticationEvent.CanManage
                ];
                break;
            case AuthenticationClass.Appellation:
                authenticationEvents =
                [
                    AuthenticationEvent.Create,
                    AuthenticationEvent.Read,
                    AuthenticationEvent.Update,
                    AuthenticationEvent.Delete,
                    AuthenticationEvent.CanManage
                ];
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(authenticationClass), authenticationClass, null);
        }

        List<AuthenticationEventView> authenticationEventViews = authenticationEvents.Select(ae => new AuthenticationEventView(ae)).ToList();

        return new Tuple<List<AuthenticationEvent>, List<AuthenticationEventView>>(authenticationEvents, authenticationEventViews);
    }

    public static bool IsNeedParameter(this AuthenticationClass authenticationClass)
    {
        switch (authenticationClass)
        {
            case AuthenticationClass.UserGroup:
                return false;
            case AuthenticationClass.ServerSettings:
                return false;
            case AuthenticationClass.Company:
                return false;
            case AuthenticationClass.Plant:
                return false;
            case AuthenticationClass.Department:
                return false;
            case AuthenticationClass.Appellation:
                return false;
            default:
                throw new ArgumentOutOfRangeException(nameof(authenticationClass), authenticationClass, null);
        }
    }

    public static Module GetGroupClass(this AuthenticationClass authenticationClass)
    {
        switch (authenticationClass)
        {
            case AuthenticationClass.UserGroup:
                return Enums.Module.Admin;
                break;
            case AuthenticationClass.ServerSettings:
                return Enums.Module.Admin;
                break;
            case AuthenticationClass.Company:
                return Enums.Module.Admin;
                break;
            case AuthenticationClass.Plant:
                return Enums.Module.Admin;
                break;
            case AuthenticationClass.Department:
                return Enums.Module.Admin;
                break;
            case AuthenticationClass.Appellation:
                return Enums.Module.Admin;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(authenticationClass), authenticationClass, null);
        }
    }
}