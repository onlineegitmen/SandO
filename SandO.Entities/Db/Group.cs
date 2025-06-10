using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("Groups")]
public class Group
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Grup Adı")]
    public string Name { get; set; }

    [Display(Name = "Açıklama")]
    [StringLength(500)]
    [JsonIgnore]
    public string? Desc { get; set; }

    [Display(Name = "Tüm İzinleri Devre Dışı Bırak")]
    public bool DisabledAllPermissions { get; set; }

    public Module GroupModule { get; set; }

    [MaxLength(50)]
    [Required]
    [DisplayName("GUID")]
    public string Guid { get; set; }

    [JsonIgnore]
    public List<UserGroup> UserGroups { get; set; }

    [JsonIgnore]
    public List<GroupPermission> GroupPermissions { get; set; }

    [NotMapped]
    [DisplayName("Modül")]
    [JsonIgnore]
    public string ModuleDesc => GroupModule.ToFriendlyString();


    public override string ToString()
    {
        return Name;
    }
}