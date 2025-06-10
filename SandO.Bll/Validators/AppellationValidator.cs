using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.Extensions;

namespace SandO.Bll.Validators;

public class AppellationValidator
{
    private Appellation Appellation { get; }
    private SandOContext Context;

    public AppellationValidator(Appellation appellation)
    {
        Appellation = appellation;
        Context = new SandOContext(GlobalVariables.DbContextOptions);
    }

    public ProgressResult Validate()
    {
        ProgressResult result = new ProgressResult(true);

        if (Appellation.Code.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Ünvan kodu boş bırakılamaz.";
        }

        if (Appellation.Code.IsMoreThanMaxLength(10))
        {
            result.Result = false;
            result.Message = "Ünvan kodu en fazla 10 karakter olabilir.";
        }

        if (AppellationCodeExists())
        {
            result.Result = false;
            result.Message = "Bu ünvan kodu zaten kullanılmaktadır.";
        }

        if (Appellation.Name.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Ünvan adı boş bırakılamaz.";
        }

        if (Appellation.Name.IsMoreThanMaxLength(50))
        {
            result.Result = false;
            result.Message = "Ünvan adı en fazla 50 karakter olabilir.";
        }

        if (Appellation.Description.IsMoreThanMaxLength(250))
        {
            result.Result = false;
            result.Message = "Açıklama en fazla 250 karakter olabilir.";
        }

        if (AppellationNameExists())
        {
            result.Result = false;
            result.Message = "Bu ünvan adı zaten kullanılmaktadır.";
        }

        return result;
    }

    private bool AppellationCodeExists()
    {
        return Context.Appellations.Any(a => a.Code == Appellation.Code && a.Id != Appellation.Id && a.RecordState == RecordState.Active);
    }

    private bool AppellationNameExists()
    {
        return Context.Appellations.Any(a => a.Name == Appellation.Name && a.Id != Appellation.Id && a.RecordState == RecordState.Active);
    }
}