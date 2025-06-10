using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.Extensions;

namespace SandO.Bll.Validators;

public class PlantValidator
{
    public Plant Plant { get; }
    private SandOContext Context;

    public PlantValidator(Plant plant)
    {
        Plant = plant;
        Context = new SandOContext(GlobalVariables.DbContextOptions);
    }

    public ProgressResult Validate()
    {
        ProgressResult result = new ProgressResult(true);

        if (Plant.Code.IsNullOrEmptyOrWhiteSpace())
        {
            result.AddMessage("Üretim yeri kodu boş bırakılamaz.");
            result.Result = false;
        }

        if (Plant.Code.IsMoreThanMaxLength(10))
        {
            result.AddMessage("Üretim yeri kodu en fazla 10 karakter olabilir.");
            result.Result = false;
        }

        if (PlantCodeExists())
        {
            result.AddMessage("Bu üretim yeri kodu zaten kullanılmaktadır.");
            result.Result = false;
        }

        if (Plant.Name.IsNullOrEmptyOrWhiteSpace())
        {
            result.AddMessage("Üretim yeri adı boş bırakılamaz.");
            result.Result = false;
        }

        if (Plant.Name.IsMoreThanMaxLength(50))
        {
            result.AddMessage("Üretim yeri adı en fazla 50 karakter olabilir.");
            result.Result = false;
        }

        if (PlantNameExists())
        {
            result.AddMessage("Bu üretim yeri adı zaten kullanılmaktadır.");
            result.Result = false;
        }

        if (!PlantCompanyExists())
        {
            result.AddMessage("Üretim yeri için bir şirket seçilmelidir.");
            result.Result = false;
        }

        Context.Dispose();

        return result;
    }

    private bool PlantCompanyExists()
    {
        return Context.Companies.Any(c => c.Id == Plant.CompanyId && c.RecordState == RecordState.Active);
    }

    private bool PlantNameExists()
    {
        return Context.Plants.Any(p => p.Name == Plant.Name && p.Id != Plant.Id && p.RecordState == RecordState.Active);
    }

    private bool PlantCodeExists()
    {
        return Context.Plants.Any(p => p.Code == Plant.Code && p.Id != Plant.Id && p.RecordState == RecordState.Active);
    }
}