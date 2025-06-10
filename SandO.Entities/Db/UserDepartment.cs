using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandO.Entities.Db;

[Table("UserDepartments")]
public class UserDepartment
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [DisplayName("Kullanıcı")]
    public User User { get; set; }

    public int CompanyId { get; set; }

    [DisplayName("Şirket")]
    public Company Company { get; set; }

    public int PlantId { get; set; }

    [DisplayName("Üretim Yeri")]
    public Plant Plant { get; set; }

    public int DepartmentId { get; set; }

    [DisplayName("Departman")]
    public Department Department { get; set; }

    public int AppellationId { get; set; }

    [DisplayName("Unvan")]
    public Appellation Appellation { get; set; }

    [DisplayName("Kayıt Zamanı")]
    public DateTime CreatedDate { get; set; }
    public int CreatedById { get; set; }

    [DisplayName("Kaydeden")]
    public User CreatedBy { get; set; }

    [DisplayName("Başlama Tarihi")]
    public DateTime StartFrom { get; set; }

    [DisplayName("Bitiş Tarihi")]
    public DateTime EndAt { get; set; }

    [DisplayName("Varsayılan")]
    public bool Default { get; set; }

    [DisplayName("Aktif")]
    public bool Active { get; set; }
}