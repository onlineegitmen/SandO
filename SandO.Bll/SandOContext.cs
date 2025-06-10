using Microsoft.EntityFrameworkCore;
using SandO.Entities.AppClasses;
using SandO.Entities.Db;

namespace SandO.Bll;

public partial class SandOContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<GroupPermission> GroupPermissions { get; set; }
    public DbSet<UserDepartment> UserDepartments { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Appellation> Appellations { get; set; }
    public DbSet<SystemSetting> SystemSettings { get; set; }
    public DbSet<PermissionFail> PermissionFails { get; set; }
    public DbSet<RecordLog> RecordLogs { get; set; }
    public DbSet<ColumnDescription> ColumnDescriptions { get; set; }

    /// <summary>
    /// SaveChanges metodunu try-catch bloğu içerisinde çalıştırır ve hata oluştuğunda false döner.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool SaveChangesSafe()
    {
        try
        {
            base.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
#if DEBUG
            throw new Exception("Veritabanı işlemi sırasında hata oluştu. Hata: " + e.Message);
#endif
            return false;

        }
    }
}