using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("Appellations")]
public class Appellation
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "Ünvan Kodu")]
    public string Code { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Ünvan Adı")]
    public string Name { get; set; }

    [StringLength(250)]
    [Display(Name = "Açıklama")]
    [JsonIgnore]
    public string Description { get; set; }

    public RecordState RecordState { get; set; }

    [MaxLength(50)]
    [Required]
    [DisplayName("GUID")]
    public string Guid { get; set; }

    [JsonIgnore]
    public List<UserDepartment> UserDepartments { get; set; }

    [JsonIgnore]
    [DisplayName("Durum")]
    public string RecordStateName => RecordState.ToDescription();

    public override string ToString()
    {
        return Name;
    }
}