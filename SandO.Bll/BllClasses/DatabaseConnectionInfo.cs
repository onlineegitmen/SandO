using SandO.Entities.Enums;

namespace SandO.Bll.BllClasses;

public struct DatabaseConnectionInfo(string connectionString, DatabaseType databaseType)
{
    public string ConnectionString { get; set; } = connectionString;
    public DatabaseType DatabaseType { get; set; } = databaseType;
}