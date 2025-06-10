using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Extensions;

namespace SandO.Bll.Validators;

public class UserValidator
{
    public User User { get; }

    public UserValidator(User user)
    {
        User = user;
    }

    public ProgressResult Validate()
    {
        ProgressResult progressResult = new(true);

        if (User.Username.IsNullOrEmptyOrWhiteSpace())
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı adı boş bırakılamaz.");
        }

        if (User.Username.IsMoreThanMaxLength(50))
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı adı en fazla 50 karakter olabilir.");
        }

        if (UsernameIsExists())
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı adı zaten kullanımda.");
        }

        if (User.Firstname.IsNullOrEmptyOrWhiteSpace())
        {
            progressResult.Result = false;
            progressResult.AddMessage("Adı boş bırakılamaz.");
        }

        if (User.Firstname.IsMoreThanMaxLength(50))
        {
            progressResult.Result = false;
            progressResult.AddMessage("Adı en fazla 50 karakter olabilir.");
        }

        if (User.Lastname.IsNullOrEmptyOrWhiteSpace())
        {
            progressResult.Result = false;
            progressResult.AddMessage("Soyadı boş bırakılamaz.");
        }

        if (User.Lastname.IsMoreThanMaxLength(50))
        {
            progressResult.Result = false;
            progressResult.AddMessage("Soyadı en fazla 50 karakter olabilir.");
        }

        if (User.ExpiredAt.HasValue && User.ExpiredAt.Value.IsBeforeNow())
        {
            progressResult.Result = false;
            progressResult.AddMessage("Hesap sona erme zamanı şu anki tarihten önce olamaz.");
        }

        if (User.EMail.IsMoreThanMaxLength(100))
        {
            progressResult.Result = false;
            progressResult.AddMessage("E-Posta en fazla 100 karakter olabilir.");
        }

        if (!User.EMail.IsValidEmailOrEmpty())
        {
            progressResult.Result = false;
            progressResult.AddMessage("E-Posta formatı geçersiz.");
        }

        if (User.Phone.IsMoreThanMaxLength(20))
        {
            progressResult.Result = false;
            progressResult.AddMessage("Telefon en fazla 20 karakter olabilir.");
        }

        return progressResult;
    }

    private bool UsernameIsExists()
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        return context.Users.Any(x => x.Username == User.Username && x.Id != User.Id);
    }
}