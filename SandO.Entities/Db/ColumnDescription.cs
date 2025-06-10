using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SandO.Entities.Db;

[Table("ColumnDescriptions")]
[PrimaryKey(nameof(TableName), nameof(ColumnName))]
public class ColumnDescription
{
    [MaxLength(200)]
    [Required]
    public string TableName { get; set; }

    [MaxLength(200)]
    [Required]
    public string ColumnName { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
}