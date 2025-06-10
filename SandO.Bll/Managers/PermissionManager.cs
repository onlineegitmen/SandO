using Microsoft.EntityFrameworkCore;
using SandO.Bll.BllClasses;
using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.Extensions;

namespace SandO.Bll.Managers;

public class PermissionManager
{
    public DatabaseConnectionInfo DatabaseConnectionInfo { get; set; }
    public int UserId { get; set; }

    public PermissionManager()
    {
        DatabaseConnectionInfo = GlobalVariables.DatabaseConnectionInfo;
        UserId = GlobalVariables.LoggedInUserId;
    }

    public PermissionManager(DatabaseConnectionInfo databaseConnectionInfo, int userId)
    {
        DatabaseConnectionInfo = databaseConnectionInfo;
        UserId = userId;
    }

    /// <summary>
    /// Check if the user has permission to perform the action
    /// </summary>
    public BoolState HasPermission(int userId, AuthenticationClass authenticationClass,
        AuthenticationEvent authenticationEvent)
    {
        using (SandOContext context = new SandOContext(GlobalVariables.DbContextOptions))
        {
            List<int> groupIds = context.UserGroups.AsNoTracking().Include(ug => ug.Group)
                .Where(g => !g.Group.DisabledAllPermissions && g.UserId == userId).Select(g => g.GroupId).ToList();
            bool any = context.GroupPermissions.AsNoTracking().Any(gp =>
                groupIds.Contains(gp.GroupId) && gp.AuthenticationClass == authenticationClass &&
                gp.AuthenticationEvent == authenticationEvent);

            if (!any)
            {
                PermissionFail permissionFail = new PermissionFail
                {
                    UserId = userId,
                    AuthenticationClass = authenticationClass,
                    AuthenticationEvent = authenticationEvent,
                    DateTime = DateTime.Now
                };
                context.PermissionFails.Add(permissionFail);
                context.SaveChangesSafe();
            }

            return any ? BoolState.True : BoolState.False;
        }
    }

    /// <summary>
    /// Check if the logged in user has permission to perform the action
    /// </summary>
    public BoolState HasPermission(AuthenticationClass authenticationClass, AuthenticationEvent authenticationEvent)
    {
        return HasPermission(GlobalVariables.LoggedInUserId, authenticationClass, authenticationEvent);
    }

    public BoolState HasAnyPermission(AuthenticationClass authenticationClass)
    {
        using (SandOContext context = new SandOContext(GlobalVariables.DbContextOptions))
        {
            List<int> groupIds = context.UserGroups.AsNoTracking().Include(ug => ug.Group)
                .Where(g => !g.Group.DisabledAllPermissions && g.UserId == UserId).Select(g => g.GroupId).ToList();
            bool any = context.GroupPermissions.AsNoTracking().Any(gp =>
                groupIds.Contains(gp.GroupId) && gp.AuthenticationClass == authenticationClass);

            return any ? BoolState.True : BoolState.False;
        }
    }

    public ProgressResult CreateAllPermissionsForAdminGroup()
    {
        SystemSettingsManager systemSettingsManager = new SystemSettingsManager(DatabaseConnectionInfo, UserId);
        QueryResult<string> systemSettingValue =
            systemSettingsManager.GetSystemSettingValue<string>(SystemSettingType.AdminGroupName);
        if (!systemSettingValue.Result)
        {
            return new ProgressResult(false, systemSettingValue.Message);
        }

        UserGroupManager userGroupManager = new UserGroupManager(DatabaseConnectionInfo, UserId);
        QueryResult<Group> adminGroup = userGroupManager.GetGroupByName(systemSettingValue.ResultObject);
        if (!adminGroup.Result)
        {
            return new ProgressResult(false, "Yönetici grubu bulunamadı.");
        }

        using SandOContext context = new SandOContext(GlobalVariables.DbContextOptions);
        List<AuthenticationClass> authenticationClasses =
            Enum.GetValues(typeof(AuthenticationClass)).Cast<AuthenticationClass>().ToList();
        foreach (AuthenticationClass authenticationClass in authenticationClasses)
        {
            foreach (AuthenticationEvent authenticationEvent in authenticationClass.GetAuthenticationEventViews().Item1)
            {
                if (context.GroupPermissions.Any(gp => gp.GroupId == adminGroup.ResultObject.Id && gp.AuthenticationClass == authenticationClass && gp.AuthenticationEvent == authenticationEvent))
                {
                    continue;
                }

                GroupPermission groupPermission = new GroupPermission
                {
                    GroupId = adminGroup.ResultObject.Id,
                    AuthenticationClass = authenticationClass,
                    AuthenticationEvent = authenticationEvent,
                    Guid = GuidExtensions.GetNewGuid()
                };
                context.GroupPermissions.Add(groupPermission);
            }
        }

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "İşlem sırasında hata oluştu.");
        }

        return new ProgressResult(true, "Yönetici grubu için tüm izinler başarıyla oluşturuldu.");
    }
}