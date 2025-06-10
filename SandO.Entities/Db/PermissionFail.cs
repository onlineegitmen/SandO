using System.ComponentModel.DataAnnotations.Schema;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("PermissionFails")]
public class PermissionFail
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AuthenticationClass AuthenticationClass { get; set; }
    public AuthenticationEvent AuthenticationEvent { get; set; }
    public DateTime DateTime { get; set; }

    public User User { get; set; }
}