using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Extensions;

namespace SandO.Bll.Validators;

public class DepartmentValidator
{
    private Department Department { get; }
    private SandOContext Context;

    public DepartmentValidator(Department department)
    {
        Department = department;
        Context = new SandOContext(GlobalVariables.DbContextOptions);
    }

    public ProgressResult Validate()
    {
        ProgressResult result = new ProgressResult(true);

        if (Department.Code.IsNullOrEmptyOrWhiteSpace())
        {
            result.AddMessage("Departman kodu boş bırakılamaz.");
            result.Result = false;
        }

        if (Department.Code.IsMoreThanMaxLength(10))
        {
            result.AddMessage("Departman kodu en fazla 10 karakter olabilir.");
            result.Result = false;
        }

        if (DepartmentCodeExists())
        {
            result.AddMessage("Bu departman kodu zaten kullanılmaktadır.");
            result.Result = false;
        }

        if (Department.Name.IsNullOrEmptyOrWhiteSpace())
        {
            result.AddMessage("Departman adı boş bırakılamaz.");
            result.Result = false;
        }

        if (Department.Name.IsMoreThanMaxLength(50))
        {
            result.AddMessage("Departman adı en fazla 50 karakter olabilir.");
            result.Result = false;
        }

        if (DepartmentNameExists())
        {
            result.AddMessage("Bu departman adı zaten kullanılmaktadır.");
            result.Result = false;
        }

        return result;
    }

    private bool DepartmentNameExists()
    {
        return Context.Departments.Any(x => x.Name == Department.Name && x.Id != Department.Id);
    }

    private bool DepartmentCodeExists()
    {
        return Context.Departments.Any(x => x.Code == Department.Code && x.Id != Department.Id);
    }
}