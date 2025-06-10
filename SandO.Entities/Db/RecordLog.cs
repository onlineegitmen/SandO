using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SandO.Entities.Enums;

namespace SandO.Entities.Db;

[Table("RecordLogs")]
public class RecordLog
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string RecordGuid { get; set; }

    public string DifferenceJson { get; set; }

    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public ActionType ActionType { get; set; }
}