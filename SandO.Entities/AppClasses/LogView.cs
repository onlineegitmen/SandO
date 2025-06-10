using System.ComponentModel;
using SandO.Entities.Enums;

namespace SandO.Entities.AppClasses;

public class LogView
{
    public int Id { get; set; }
    public ActionType ActionType { get; set; }
    public int UserId { get; set; }

    [DisplayName("İşlem Tarihi")]
    public DateTime DateTime { get; set; }

    [DisplayName("İşlem Yapan Kişi")]
    public string UserFullname { get; set; }

    [DisplayName("Kullanıcı Adı")]
    public string Username { get; set; }


    public string ActionTypeName => ActionType.GetDescription();
}