using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("Departments")]
public class Department
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "Departman Kodu")]
    public string Code { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Departman Adı")]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    [DisplayName("GUID")]
    public string Guid { get; set; }

    public RecordState RecordState { get; set; }

    [JsonIgnore]
    public List<UserDepartment> UserDepartments { get; set; }

    public override string ToString()
    {
        return Name;
    }

    [NotMapped]
    [JsonIgnore]
    public static string ObjectType => "Department";

    [NotMapped]
    [JsonIgnore]
    [DisplayName("Durum")]
    public string RecordStateDescription => RecordState.ToDescription();
}