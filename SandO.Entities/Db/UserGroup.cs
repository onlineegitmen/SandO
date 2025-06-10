using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SandO.Entities.Db;

[PrimaryKey(nameof(UserId), nameof(GroupId))]
[Table("UserGroups")]
public class UserGroup
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }

    [MaxLength(50)]
    public string Guid { get; set; }
}