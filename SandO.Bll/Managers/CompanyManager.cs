using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using SandO.Bll.BllClasses;
using SandO.Bll.Helpers;
using SandO.Bll.Validators;
using SandO.Entities.AppClasses;
using SandO.Entities.AppClasses.Organization;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.Extensions;

namespace SandO.Bll.Managers;

/// <summary>
/// Şirket, üretim yeri, departman ve ünvan işlemleri
/// </summary>
public class CompanyManager
{
    public DatabaseConnectionInfo DatabaseConnectionInfo { get; set; }
    public int UserId { get; set; }
    public CompanyManager()
    {
        DatabaseConnectionInfo = GlobalVariables.DatabaseConnectionInfo;
        UserId = GlobalVariables.LoggedInUserId;
    }

    public CompanyManager(DatabaseConnectionInfo databaseConnectionInfo, int userId)
    {
        DatabaseConnectionInfo = databaseConnectionInfo;
        UserId = userId;
    }

    public QueryResult<List<Company>> GetCompanies()
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Company, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<Company>>(false, "Şirketleri görme yetkiniz yok.");
        }

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<Company> companies = context.Companies.AsNoTracking().OrderBy(c => c.Name).ToList();
        return new QueryResult<List<Company>>(true, companies);
    }

    public QueryResult<Company> GetCompany(int companyId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Company, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<Company>(false, "Şirketi görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Company? company = context.Companies.AsNoTracking().FirstOrDefault(c => c.Id == companyId);
        if (company == null)
        {
            return new QueryResult<Company>(false, "Şirket bulunamadı.");
        }

        return new QueryResult<Company>(true, company);
    }

    public ProgressResult AddCompany(Company company)
    {
        CompanyValidator companyValidator = new CompanyValidator(company);
        ProgressResult progressResult = companyValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }

        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Company, AuthenticationEvent.Create);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Şirket eklemeye yetkiniz yok.");
        }

        company.Guid = GuidExtensions.GetNewGuid();
        company.RecordState = RecordState.Active;

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        context.Companies.Add(company);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Şirket eklenirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(company.Guid, ActionType.Create, null, company);

        return new ProgressResult(true, "Şirket başarıyla eklendi.");
    }

    public ProgressResult UpdateCompany(Company company)
    {
        CompanyValidator companyValidator = new CompanyValidator(company);
        ProgressResult progressResult = companyValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Company, AuthenticationEvent.Update);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Şirket güncelleme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Company? companyDb = context.Companies.FirstOrDefault(c => c.Id == company.Id);
        if (companyDb == null)
        {
            return new ProgressResult(false, "Şirket bulunamadı.");
        }

        if (companyDb.RecordState != RecordState.Active)
        {
            return new ProgressResult(false, "Sadece aktif şirketler güncellenebilir.");
        }

        Company? companyForLog = context.Companies.AsNoTracking().FirstOrDefault(c => c.Id == company.Id);

        companyDb.Code = company.Code;
        companyDb.Name = company.Name;
        companyDb.TaxNumber = company.TaxNumber;
        companyDb.TaxOffice = company.TaxOffice;
        companyDb.TradeRegistryNumber = company.TradeRegistryNumber;
        companyDb.RecordState = company.RecordState;
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Şirket güncellenirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(company.Guid, ActionType.Update, companyForLog , company);
        return new ProgressResult(true, "Şirket başarıyla güncellendi.");
    }

    public ProgressResult DeleteCompany(int companyId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Company, AuthenticationEvent.Delete);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Şirket silme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        
        Company? company = context.Companies.FirstOrDefault(c => c.Id == companyId);
        if (company == null)
        {
            return new ProgressResult(false, "Şirket bulunamadı.");
        }

        if (company.RecordState != RecordState.Active)
        {
            return new ProgressResult(false, "Sadece aktif şirketler silinebilir.");
        }

        company.RecordState = RecordState.Deleted;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Şirket silinirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog<Company>(company.Guid, ActionType.Delete, null, null);
        return new ProgressResult(true, "Şirket başarıyla silindi.");
    }

    /// <summary>
    /// Kullanıcının bağlı olduğu şirketleri getirir
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public QueryResult<List<CompanyForSelection>> GetCompaniesByUser(int userId)
    {
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<CompanyForSelection> companies = context.UserDepartments.Include(uc => uc.Company).Where(uc => uc.UserId == userId && uc.Company.RecordState == RecordState.Active && uc.EndAt < DateTime.Now)
            .Select(uc => new CompanyForSelection
            {
                Id = uc.CompanyId,
                Name = uc.Company.Name
            }).OrderBy(c => c.Name).ToList();
        companies = companies.Distinct().ToList();
        return new QueryResult<List<CompanyForSelection>>(true, companies);
    }

    /// <summary>
    /// Oturum açan kullanıcının bağlı olduğu şirketleri getirir
    /// </summary>
    /// <returns></returns>
    public QueryResult<List<CompanyForSelection>> GetCompaniesByUser()
    {
        return GetCompaniesByUser(UserId);
    }

    public QueryResult<List<Plant>> GetPlants()
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<Plant>>(false, "Üretim yerlerini görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<Plant> plants = context.Plants.AsNoTracking().Include(p => p.Company).Where(p => p.Company.RecordState == RecordState.Active).OrderBy(p => p.Name).ToList();
        return new QueryResult<List<Plant>>(true, plants);
    }

    public QueryResult<Plant> GetPlant(int plantId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<Plant>(false, "Üretim yeri görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Plant? plant = context.Plants.AsNoTracking().Include(p => p.Company).FirstOrDefault(p => p.Id == plantId);
        if (plant == null)
        {
            return new QueryResult<Plant>(false, "Üretim yeri bulunamadı.");
        }
        return new QueryResult<Plant>(true, plant);
    }

    public ProgressResult AddPlant(Plant plant)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Create);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Üretim yeri eklemeye yetkiniz yok.");
        }

        PlantValidator plantValidator = new PlantValidator(plant);
        ProgressResult progressResult = plantValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }

        plant.Guid = GuidExtensions.GetNewGuid();
        plant.RecordState = RecordState.Active;

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        context.Plants.Add(plant);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Üretim yeri eklenirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(plant.Guid, ActionType.Create, null, plant);
        return new ProgressResult(true, "Üretim yeri başarıyla eklendi.");
    }

    public ProgressResult UpdatePlant(Plant plant)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Update);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Üretim yeri güncelleme yetkiniz yok.");
        }
        PlantValidator plantValidator = new PlantValidator(plant);
        ProgressResult progressResult = plantValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Plant? plantDb = context.Plants.FirstOrDefault(p => p.Id == plant.Id);
        if (plantDb == null)
        {
            return new ProgressResult(false, "Üretim yeri bulunamadı.");
        }
        Plant? plantForLog = context.Plants.AsNoTracking().FirstOrDefault(p => p.Id == plant.Id);
        plantDb.Code = plant.Code;
        plantDb.Name = plant.Name;
        plantDb.CompanyId = plant.CompanyId;
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Üretim yeri güncellenirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog(plant.Guid, ActionType.Update, plantForLog, plant);
        return new ProgressResult(true, "Üretim yeri başarıyla güncellendi.");
    }

    public ProgressResult DeletePlant(int plantId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Delete);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Üretim yeri silme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);

        Plant? plant = context.Plants.FirstOrDefault(p => p.Id == plantId);
        if (plant == null)
        {
            return new ProgressResult(false, "Üretim yeri bulunamadı.");
        }

        if (plant.RecordState != RecordState.Active)
        {
            return new ProgressResult(false, "Sadece aktif üretim yerleri silinebilir.");
        }

        plant.RecordState = RecordState.Deleted;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Üretim yeri silinirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog<Plant>(plant.Guid, ActionType.Delete, null, null);
        return new ProgressResult(true, "Üretim yeri başarıyla silindi.");
    }

    public QueryResult<List<PlantForSelection>> GetCompanyPlants(int companyId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<PlantForSelection>>(false, "Üretim yerlerini görme yetkiniz yok.");
        }

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<PlantForSelection> plants = context.Plants.Include(p => p.Company).Where(p => p.CompanyId == companyId && p.RecordState == RecordState.Active && p.Company.RecordState == RecordState.Active).Select(p => new PlantForSelection
        {
            Name = p.Name,
            Id = p.Id,
            CompanyId = p.CompanyId
        }).OrderBy(p => p.Name).ToList();
        return new QueryResult<List<PlantForSelection>>(true, plants);
    }

    public QueryResult<List<PlantForSelection>> GetUserPlants(int userId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Plant, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<PlantForSelection>>(false, "Üretim yerlerini görme yetkiniz yok.");
        }

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<PlantForSelection> plants = context.UserDepartments.Where(ud => ud.UserId == userId && ud.EndAt < DateTime.Now).Select(ud => new PlantForSelection
        {
            Name = ud.Plant.Name,
            Id = ud.PlantId,
            CompanyId = ud.Plant.CompanyId
        })
            .OrderBy(p => p.Name).ToList();

        plants = plants.Distinct().ToList();
        return new QueryResult<List<PlantForSelection>>(true, plants);

    }

    /// <summary>
    /// Oturum açan kullanıcının bağlı olduğu üretim yerlerini getirir
    /// </summary>
    /// <returns></returns>
    public QueryResult<List<PlantForSelection>> GetUserPlants()
    {
        return GetUserPlants(UserId);
    }

    public QueryResult<List<Department>> GetDepartments()
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Department, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<Department>>(false, "Departmanları görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<Department> departments = context.Departments.AsNoTracking().OrderBy(d => d.Name).ToList();
        return new QueryResult<List<Department>>(true, departments);
    }

    public QueryResult<Department> GetDepartment(int departmentId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Department, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<Department>(false, "Departmanı görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Department? department = context.Departments.AsNoTracking().FirstOrDefault(d => d.Id == departmentId);
        if (department == null)
        {
            return new QueryResult<Department>(false, "Departman bulunamadı.");
        }
        return new QueryResult<Department>(true, department);
    }

    public ProgressResult AddDepartment(Department department)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Department, AuthenticationEvent.Create);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Departman eklemeye yetkiniz yok.");
        }
        DepartmentValidator departmentValidator = new DepartmentValidator(department);
        ProgressResult progressResult = departmentValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }

        department.Guid = GuidExtensions.GetNewGuid();
        department.RecordState = RecordState.Active;

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        context.Departments.Add(department);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Departman eklenirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog(department.Guid, ActionType.Create, null, department);
        return new ProgressResult(true, "Departman başarıyla eklendi.");
    }

    public ProgressResult UpdateDepartment(Department department)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Department, AuthenticationEvent.Update);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Departman güncelleme yetkiniz yok.");
        }
        DepartmentValidator departmentValidator = new DepartmentValidator(department);
        ProgressResult progressResult = departmentValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Department? departmentDb = context.Departments.FirstOrDefault(d => d.Id == department.Id);
        if (departmentDb == null)
        {
            return new ProgressResult(false, "Departman bulunamadı.");
        }
        Department? departmentForLog = context.Departments.AsNoTracking().FirstOrDefault(d => d.Id == department.Id);
        departmentDb.Code = department.Code;
        departmentDb.Name = department.Name;
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Departman güncellenirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog(department.Guid, ActionType.Update, departmentForLog, department);
        return new ProgressResult(true, "Departman başarıyla güncellendi.");
    }

    public ProgressResult DeleteDepartment(int departmentId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Department, AuthenticationEvent.Delete);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Departman silme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        
        Department? department = context.Departments.FirstOrDefault(d => d.Id == departmentId);
        if (department == null)
        {
            return new ProgressResult(false, "Departman bulunamadı.");
        }

        if (department.RecordState != RecordState.Active)
        {
            return new ProgressResult(false, "Sadece aktif departmanlar silinebilir.");
        }

        department.RecordState = RecordState.Deleted;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Departman silinirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog<Department>(department.Guid, ActionType.Delete, null, null);
        return new ProgressResult(true, "Departman başarıyla silindi.");
    }

    public QueryResult<List<Appellation>> GetAppellations()
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<Appellation>>(false, "Ünvanları görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<Appellation> appellations = context.Appellations.AsNoTracking().OrderBy(a => a.Name).ToList();
        return new QueryResult<List<Appellation>>(true, appellations);
    }

    public QueryResult<Appellation> GetAppellation(int appellationId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<Appellation>(false, "Ünvanı görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Appellation? appellation = context.Appellations.AsNoTracking().FirstOrDefault(a => a.Id == appellationId);
        if (appellation == null)
        {
            return new QueryResult<Appellation>(false, "Ünvan bulunamadı.");
        }
        return new QueryResult<Appellation>(true, appellation);
    }

    public ProgressResult AddAppellation(Appellation appellation)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.Create);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Ünvan eklemeye yetkiniz yok.");
        }
        AppellationValidator appellationValidator = new AppellationValidator(appellation);
        ProgressResult progressResult = appellationValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }

        appellation.Guid = GuidExtensions.GetNewGuid();
        appellation.RecordState = RecordState.Active;

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        context.Appellations.Add(appellation);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Ünvan eklenirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog(appellation.Guid, ActionType.Create, null, appellation);
        return new ProgressResult(true, "Ünvan başarıyla eklendi.");
    }

    public ProgressResult UpdateAppellation(Appellation appellation)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.Update);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Ünvan güncelleme yetkiniz yok.");
        }
        AppellationValidator appellationValidator = new AppellationValidator(appellation);
        ProgressResult progressResult = appellationValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        Appellation? appellationDb = context.Appellations.FirstOrDefault(a => a.Id == appellation.Id);
        if (appellationDb == null)
        {
            return new ProgressResult(false, "Ünvan bulunamadı.");
        }

        Appellation? appellationForLog = context.Appellations.AsNoTracking().FirstOrDefault(a => a.Id == appellation.Id);

        appellationDb.Code = appellation.Code;
        appellationDb.Name = appellation.Name;
        appellationDb.Description = appellation.Description;
        appellationDb.RecordState = appellation.RecordState;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Ünvan güncellenirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog(appellation.Guid, ActionType.Update, appellationForLog, appellation);
        return new ProgressResult(true, "Ünvan başarıyla güncellendi.");
    }

    public ProgressResult DeleteAppellation(int appellationId)
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Appellation, AuthenticationEvent.Delete);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Ünvan silme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        
        Appellation? appellation = context.Appellations.FirstOrDefault(a => a.Id == appellationId);
        if (appellation == null)
        {
            return new ProgressResult(false, "Ünvan bulunamadı.");
        }

        if (appellation.RecordState != RecordState.Active)
        {
            return new ProgressResult(false, "Sadece aktif ünvanlar silinebilir.");
        }

        appellation.RecordState = RecordState.Deleted;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Ünvan silinirken bir hata oluştu.");
        }
        NewtonJsonHelper.SaveLog<Appellation>(appellation.Guid, ActionType.Delete, null, null);
        return new ProgressResult(true, "Ünvan başarıyla silindi.");
    }

    public QueryResult<List<UserDepartment>> GetUserDepartments()
    {
        PermissionManager permissionManager = new PermissionManager(DatabaseConnectionInfo, UserId);
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.Department, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<UserDepartment>>(false, "Kullanıcı departmanlarını görme yetkiniz yok.");
        }
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<UserDepartment> userDepartments = context.UserDepartments.AsNoTracking().Include(ud => ud.Department).Include(ud => ud.Company).Include(ud => ud.Plant).Include(ud => ud.Appellation).OrderBy(ud => ud.Department.Name).ToList();

        return new QueryResult<List<UserDepartment>>(true, userDepartments);
    }

    /// <summary>
    /// Seçimlerde kullanılmak üzere şirketleri getirir
    /// </summary>
    /// <param name="all">
    /// Tüm şirketleri getirir. false ise sadece aktif olanları getirir
    /// </param>
    /// <returns></returns>
    public QueryResult<List<CompanyForSelection>> GetCompaniesForSelection(bool all = false, bool includePlants = false)
    {
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<CompanyForSelection> companies = context.Companies.AsNoTracking().Where(c => all || c.RecordState == RecordState.Active).Select(c => new CompanyForSelection
        {
            Id = c.Id,
            Name = c.Name
        }).OrderBy(c => c.Name).ToList();


        if (includePlants)
        {
            foreach (CompanyForSelection companyForSelection in companies)
            {
                companyForSelection.PlantForSelections = context.Plants.AsNoTracking()
                    .Where(p => p.CompanyId == companyForSelection.Id && p.RecordState == RecordState.Active)
                    .Select(p => new PlantForSelection
                    {
                        CompanyId = p.CompanyId,
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
            }
        }

        return new QueryResult<List<CompanyForSelection>>(true, companies);
    }

    public QueryResult<List<DepartmentForSelection>> GetDepartmentsForSelection()
    {
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<DepartmentForSelection> departments = context.Departments.Where(d => d.RecordState == RecordState.Active).Select(d => new DepartmentForSelection
        {
            Id = d.Id,
            Name = d.Name
        }).OrderBy(d => d.Name).ToList();
        return new QueryResult<List<DepartmentForSelection>>(true, departments);
    }

    public QueryResult<List<AppellationForSelection>> GetAppellationsForSelection()
    {
        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<AppellationForSelection> appellations = context.Appellations.Where(a => a.RecordState == RecordState.Active).Select(a => new AppellationForSelection
        {
            Id = a.Id,
            Name = a.Name
        }).OrderBy(a => a.Name).ToList();
        return new QueryResult<List<AppellationForSelection>>(true, appellations);
    }
}