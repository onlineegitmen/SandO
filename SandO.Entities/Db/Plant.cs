using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("Plants")]
public class Plant
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "Üretim Yeri Kodu")]
    public string Code { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Üretim Yeri Adı")]
    public string Name { get; set; }

    public int CompanyId { get; set; }

    [JsonIgnore]
    public Company Company { get; set; }

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

    [JsonIgnore]
    public static string ObjectType => "Plant";


    #region Not Mapped

    [NotMapped]
    [JsonIgnore]
    [DisplayName("Şirket")]
    public string CompanyName => Company?.Name ?? string.Empty;

    [NotMapped]
    [JsonIgnore]
    [DisplayName("Durum")]
    public string RecordStateName => RecordState.ToDescription();

    #endregion Not Mapped
}