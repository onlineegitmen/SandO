using System.ComponentModel;

namespace SandO.Entities.AppClasses;

public class LogValue
{
    [DisplayName("Teknik Adı")]
    public string Propertname { get; set; }

    [DisplayName("Alan Adı")]
    public string PropertyDesc { get; set; }

    [DisplayName("Eski Değer")]
    public string OldValue { get; set; }

    [DisplayName("Yeni Değer")]
    public string NewValue { get; set; }
}