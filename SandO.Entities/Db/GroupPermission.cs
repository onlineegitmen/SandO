using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("GroupPermissions")]
[PrimaryKey(nameof(GroupId), nameof(AuthenticationClass), nameof(AuthenticationEvent))]
public class GroupPermission
{
    public int GroupId { get; set; }
    public AuthenticationClass AuthenticationClass { get; set; }
    public AuthenticationEvent AuthenticationEvent { get; set; }

    public Group Group { get; set; }

    [MaxLength(50)]
    public string Guid { get; set; }
}