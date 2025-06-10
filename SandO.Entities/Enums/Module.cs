namespace SandO.Entities.Enums;

public enum Module
{
    Admin,
}

public static partial class EnumExtensions
{
    public static string ToFriendlyString(this Module me)
    {
        switch (me)
        {
            case Enums.Module.Admin:
                return "Yönetim";
            default:
                throw new ArgumentOutOfRangeException(nameof(me), me, null);
        }
    }

    public class ModuleView(Module module)
    {
        public Module Module { get; set; } = module;
        public string Name => Module.ToFriendlyString();
        public override string ToString()
        {
            return Name;
        }
        public static List<ModuleView> GetModuleViews()
        {
            return Enum.GetValues<Module>().Select(x => new ModuleView(x)).ToList();
        }
    }

    public static Tuple<List<AuthenticationClass>, List<AuthenticationClassView>> GetAuthenticationEventViews(this Module module)
    {
        List<AuthenticationClass> authenticationClasses;
        switch (module)
        {
            case Enums.Module.Admin:
                authenticationClasses =
                [
                    AuthenticationClass.UserGroup,
                    AuthenticationClass.ServerSettings,
                    AuthenticationClass.Company,
                    AuthenticationClass.Plant,
                    AuthenticationClass.Department,
                    AuthenticationClass.Appellation
                ];
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(module), module, null);
        }
        return new Tuple<List<AuthenticationClass>, List<AuthenticationClassView>>(
            authenticationClasses,
            authenticationClasses.Select(x => new AuthenticationClassView(x)).OrderBy(a => a.Name).ToList()
        );
    }
}