using Microsoft.EntityFrameworkCore;
using SandO.Bll.BllClasses;
using SandO.Entities.AppClasses;
using SandO.Entities.Enums;

namespace SandO.Bll;

public static class GlobalVariables
{
    public static UserView? LoggedInUser { get; set; }
    public static int LoggedInUserId => LoggedInUser?.Id ?? 0;
    public static DatabaseConnectionInfo DatabaseConnectionInfo { get; set; }

    public static DbContextOptions DbContextOptions
    {
        get
        {
            DbContextOptionsBuilder<SandOContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SandOContext>();
            dbContextOptionsBuilder.UseSqlServer(DatabaseConnectionInfo.ConnectionString);
            return dbContextOptionsBuilder.Options;
        }
    }
}