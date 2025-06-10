using SandO.Entities.Db;

namespace SandO.Entities.AppClasses.Organization;

public class UserDepartmentView
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string User { get; set; }

    public int CompanyId { get; set; }
    public string Company { get; set; }

    public int PlantId { get; set; }
    public string Plant { get; set; }

    public int DepartmentId { get; set; }
    public string Department { get; set; }

    public int AppellationId { get; set; }
    public string Appellation { get; set; }

    public DateTime CreatedDate { get; set; }
    public int CreatedById { get; set; }
    public string CreatedBy { get; set; }

    public DateTime StartFrom { get; set; }
    public DateTime EndAt { get; set; }

    public bool Default { get; set; }
}