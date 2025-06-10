using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("Users")]
public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
    [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir.")]
    [DisplayName("Kullanıcı Adı")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Adı boş bırakılamaz.")]
    [StringLength(50, ErrorMessage = "Adı en fazla 50 karakter olabilir.")]
    [DisplayName("Adı")]
    public string Firstname { get; set; }

    [Required(ErrorMessage = "Soyadı boş bırakılamaz.")]
    [StringLength(50, ErrorMessage = "Soyadı en fazla 50 karakter olabilir.")]
    [DisplayName("Soyadı")]
    public string Lastname { get; set; }

    [MaxLength(100)]
    [JsonIgnore]
    public string? PasswordHash { get; set; }

    public bool NeedChangePassword { get; set; }

    [DisplayName("Son Şifre Değişikliği")]
    public DateTime? LastPasswordSetDate { get; set; }

    [DisplayName("Son Giriş Tarihi")]
    public DateTime? LastLoginDate { get; set; }

    [DisplayName("Başarısız Giriş Denemesi")]
    public int FailedLoginAttempt { get; set; }

    public RecordState RecordState { get; set; }

    [Required]
    [MaxLength(50)]
    public string Guid { get; set; }

    [DisplayName("E-Posta")]
    [MaxLength(100)]
    public string EMail { get; set; }

    [DisplayName("Telefon")]
    [MaxLength(20)]
    public string Phone { get; set; }

    #region State Infos

    [DisplayName("Hesap Sona Erme Zamanı")]
    public DateTime? ExpiredAt { get; set; }

    public int? DefaultUserDepartmentId { get; set; }

    [JsonIgnore]
    public UserDepartment? DefaultUserDepartment { get; set; }

    #endregion State Infos

    #region Lists

    [JsonIgnore]
    public List<UserGroup>? UserGroups { get; set; }

    [JsonIgnore]
    public List<UserDepartment> UserDepartments { get; set; }

    [JsonIgnore]
    public List<UserDepartment> CreatedByUserDepartments { get; set; }

    [JsonIgnore]
    public List<PermissionFail> PermissionFails { get; set; }

    #endregion Lists

    #region NotMapped

    [NotMapped]
    [JsonIgnore]
    [DisplayName("Adı Soyadı")]
    public string Fullname => $"{Firstname} {Lastname}";

    #endregion NotMapped

    public override string ToString()
    {
        return Fullname;
    }
}