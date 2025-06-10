using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("Companies")]
public class Company
{
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    [DisplayName("Şirket Kodu")]
    public string Code { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Şirket Adı")]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    [DisplayName("Vergi Numarası")]
    public string TaxNumber { get; set; }

    [Required]
    [MaxLength(100)]
    [DisplayName("Vergi Dairesi")]
    public string TaxOffice { get; set; }

    [Required]
    [MaxLength(20)]
    [DisplayName("Ticaret Sicil Numarası")]
    public string TradeRegistryNumber { get; set; }

    [DisplayName("Durum")]
    public RecordState RecordState { get; set; }

    [DisplayName("GUID")]
    [MaxLength(50)]
    [Required]
    public string Guid { get; set; }

    [JsonIgnore]
    public List<Plant> Plants { get; set; }

    [JsonIgnore]
    public List<UserDepartment> UserDepartments { get; set; }

    public override string ToString()
    {
        return Name;
    }

    #region NotMapped


    [NotMapped]
    [JsonIgnore]
    public static string ObjectType => "Company";

    [NotMapped]
    [DisplayName("Durum")]
    [JsonIgnore]
    public string RecordStateDescription => RecordState.ToDescription();

    #endregion NotMapped
}