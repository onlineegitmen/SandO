using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SandO.Entities.Enums;
using ValueType = SandO.Entities.Enums.ValueType;

namespace SandO.Entities.Db;

[PrimaryKey(nameof(SystemSettingType))]
[Table("SystemSettings")]
public class SystemSetting
{
    public SystemSettingType SystemSettingType { get; set; }
    public string Value { get; set; }

    [NotMapped]
    [DisplayName("Ayar Adı")]
    public string SystemSettingTypeFriendlyString => SystemSettingType.ToFriendlyString();

    [NotMapped]
    [DisplayName("Ayar Veri Tipi")]
    public string ValueTypeFriendlyString => SystemSettingType.SettingValueType().ToFriendlyString();

    [NotMapped]
    public ValueType ValueType => SystemSettingType.SettingValueType();

    [NotMapped]
    [DisplayName("Açıklama")]
    public string Description => SystemSettingType.Description();

    [NotMapped]
    [DisplayName("Varsayılan Değer")]
    public string DefaultValue => SystemSettingType.DefaultValue();

    [NotMapped]
    [DisplayName("Modül")]
    public Module Module => SystemSettingType.Module();

    [NotMapped]
    [DisplayName("Düzenlenebilir")]
    public bool Editable => SystemSettingType.IsEditable();
}