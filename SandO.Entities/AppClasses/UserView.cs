using System.ComponentModel;
using SandO.Entities.Enums;

namespace SandO.Entities.AppClasses;

public class UserView
{
    public int Id { get; set; }

    [DisplayName("Kullanıcı Adı")]
    public string Username { get; set; }

    [DisplayName("Adı")]
    public string Firstname { get; set; }

    [DisplayName("Soyadı")]
    public string Lastname { get; set; }

    [DisplayName("Son Şifre Değişikliği")]
    public DateTime? LastPasswordSetDate { get; set; }

    [DisplayName("Son Giriş Tarihi")]
    public DateTime? LastLoginDate { get; set; }
    public RecordState RecordState { get; set; }

    [DisplayName("Hesap Sona Erme Zamanı")]
    public DateTime? ExpiredAt { get; set; }

    [DisplayName("Adı Soyadı")]
    public string Fullname => $"{Firstname} {Lastname}";

    [DisplayName("Durum")]
    public string RecordStateDescription => RecordState.ToDescription();

    [DisplayName("GUID")]
    public string Guid { get; set; }

    [DisplayName("E-Posta")]
    public string EMail { get; set; }

    [DisplayName("Telefon")]
    public string Phone { get; set; }
}