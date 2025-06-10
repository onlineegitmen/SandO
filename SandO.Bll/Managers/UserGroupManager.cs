using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SandO.Bll.BllClasses;
using SandO.Bll.Helpers;
using SandO.Bll.Validators;
using SandO.Entities.AppClasses;
using SandO.Entities.AppClasses.Organization;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.Extensions;

namespace SandO.Bll.Managers;

public class UserGroupManager
{
    public DatabaseConnectionInfo DatabaseConnectionInfo { get; set; }
    public int UserId { get; set; }
    public UserGroupManager()
    {
        DatabaseConnectionInfo = GlobalVariables.DatabaseConnectionInfo;
        UserId = GlobalVariables.LoggedInUserId;
    }

    public UserGroupManager(DatabaseConnectionInfo databaseConnectionInfo, int userId)
    {
        DatabaseConnectionInfo = databaseConnectionInfo;
        UserId = userId;
    }

    public ProgressResult AddGroup(Group group)
    {
        GroupValidator groupValidator = new(group);
        ProgressResult progressResult = groupValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }

        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Create);
        if (hasPermission != BoolState.True)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Grup oluşturma yetkiniz yok.");
            return progressResult;
        }

        group.Guid = GuidExtensions.GetNewGuid();

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        context.Groups.Add(group);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Grup oluşturulurken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(group.Guid, ActionType.Create, null, group);

        return new ProgressResult(true, "Grup başarıyla oluşturuldu.");
    }

    public ProgressResult UpdateGroup(Group group)
    {
        GroupValidator groupValidator = new(group);
        ProgressResult progressResult = groupValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Update);
        if (hasPermission != BoolState.True)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Grup güncelleme yetkiniz yok.");
            return progressResult;
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        Group? groupOnDb = context.Groups.FirstOrDefault(g => g.Id == group.Id);
        if (groupOnDb == null)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Grup bulunamadı.");
            return progressResult;
        }

        Group? groupForLog = context.Groups.AsNoTracking().FirstOrDefault(g => g.Id == group.Id);

        groupOnDb.Name = group.Name;
        groupOnDb.Desc = group.Desc;
        groupOnDb.DisabledAllPermissions = group.DisabledAllPermissions;
        groupOnDb.GroupModule = group.GroupModule;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Grup güncellenirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(groupOnDb.Guid, ActionType.Update, groupForLog, group);

        return new ProgressResult(true, "Grup başarıyla güncellendi.");
    }

    public ProgressResult DeleteGroup(int groupId)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Delete);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Grup silme yetkiniz yok.");
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        Group? group = context.Groups.FirstOrDefault(g => g.Id == groupId);
        if (group == null)
        {
            return new ProgressResult(false, "Grup bulunamadı.");
        }
        context.Groups.Remove(group);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Grup silinirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(group.Guid, ActionType.Delete, group, null);
        return new ProgressResult(true, "Grup başarıyla silindi.");
    }

    public QueryResult<List<Group>> GetGroups()
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<Group>>(false, "Grupları görüntüleme yetkiniz yok.");
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        List<Group> groups = context.Groups.ToList();
        return new QueryResult<List<Group>>(true, "Gruplar başarıyla getirildi.", groups);
    }

    public ProgressResult SetUserGroups(int id, List<UserGroup> userGroups, ObjectType objectType)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.AssignUserOrGroup);
        if (hasPermission != BoolState.True)
        {
            switch (objectType)
            {
                case ObjectType.User:
                    return new ProgressResult(false, "Kullanıcı gruplarını ayarlama yetkiniz yok.");
                    break;
                case ObjectType.Group:
                    return new ProgressResult(false, "Grup üyelerini ayarlama yetkiniz yok.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null);
            }
        }

        userGroups.ForEach(gp =>
        {
            switch (objectType)
            {
                case ObjectType.User:
                    gp.UserId = id;
                    break;
                case ObjectType.Group:
                    gp.GroupId = id;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null);
            }
        });

        using SandOContext context = new(GlobalVariables.DbContextOptions);

        List<UserGroup> userGroupsFromDb;
        switch (objectType)
        {
            case ObjectType.User:
                userGroupsFromDb = context.UserGroups.Where(gp => gp.UserId == id).ToList();
                break;
            case ObjectType.Group:
                userGroupsFromDb = context.UserGroups.Where(gp => gp.GroupId == id).ToList();
                break;
            default:
                userGroupsFromDb = new List<UserGroup>();
                break;
        }

        List<UserGroup> deletedUserGroups = userGroupsFromDb.Where(g2 => !userGroups.Any(g1 =>
                g2.GroupId == g1.GroupId && g2.UserId == g1.UserId))
            .ToList();
        context.UserGroups.RemoveRange(deletedUserGroups);

        List<UserGroup> newUserGroups = userGroups.Where(g1 => !userGroupsFromDb.Any(g2 =>
                g1.UserId == g2.UserId && g1.GroupId == g2.GroupId))
            .ToList();

        foreach (UserGroup newGroupPermission in newUserGroups)
        {
            newGroupPermission.Guid = GuidExtensions.GetNewGuid();
            context.UserGroups.Add(newGroupPermission);
        }

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Grup izinleri kaydedilirken bir hata oluştu.");
        }

        foreach (UserGroup groupPermission in deletedUserGroups)
        {
            NewtonJsonHelper.SaveLog<GroupPermission>(groupPermission.Guid, ActionType.Delete, null, null);
        }
        foreach (UserGroup groupPermission in newUserGroups)
        {
            NewtonJsonHelper.SaveLog(groupPermission.Guid, ActionType.Create, null, groupPermission);
        }

        return new ProgressResult(true, "Grup izinleri başarıyla kaydedildi.");
    }

    public ProgressResult SetGroupMemebers(int groupId, List<int> userIds)
    {
        List<UserGroup> newUserGroups = new();
        foreach (int userId in userIds)
        {
            newUserGroups.Add(new UserGroup
            {
                UserId = userId,
                GroupId = groupId
            });
        }
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.AssignUserOrGroup);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Grup üyeleri ayarlama yetkiniz yok.");
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        using (IDbContextTransaction transection = context.Database.BeginTransaction())
        {
            List<UserGroup> userGroups = context.UserGroups.Where(ug => ug.GroupId == groupId).ToList();
            context.UserGroups.RemoveRange(userGroups);
            bool saveChanges = context.SaveChangesSafe();
            if (!saveChanges)
            {
                transection.RollbackAsync();
                return new ProgressResult(false, "Grup üyeleri ayarlanırken bir hata oluştu.");
            }
            context.UserGroups.AddRange(newUserGroups);
            saveChanges = context.SaveChangesSafe();
            if (!saveChanges)
            {
                transection.RollbackAsync();
                return new ProgressResult(false, "Grup üyeleri ayarlanırken bir hata oluştu.");
            }
            transection.CommitAsync();
        }
        return new ProgressResult(true, "Grup üyeleri başarıyla ayarlandı.");
    }

    public QueryResult<List<Group>> GetUserGroups(int userId)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<Group>>(false, "Kullanıcı gruplarını görüntüleme yetkiniz yok.");
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        List<Group> groups = context.UserGroups.Include(ug => ug.Group).Where(ug => ug.UserId == userId).Select(ug => ug.Group).ToList();
        return new QueryResult<List<Group>>(true, "Kullanıcı grupları başarıyla getirildi.", groups);
    }

    public QueryResult<List<User>> GetGroupMembers(int groupId)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<User>>(false, "Grup üyelerini görüntüleme yetkiniz yok.");
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        List<User> users = context.UserGroups.Include(ug => ug.User).Where(ug => ug.GroupId == groupId).Select(ug => ug.User).ToList();
        return new QueryResult<List<User>>(true, "Grup üyeleri başarıyla getirildi.", users);
    }

    public ProgressResult AddUser(User user)
    {
        UserValidator userValidator = new(user);
        ProgressResult progressResult = userValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }

        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Create);
        if (hasPermission != BoolState.True)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı oluşturma yetkiniz yok.");
            return progressResult;
        }

        if (user.PasswordHash != null && user.PasswordHash.IsNotNullOrEmptyOrWhiteSpace())
        {
            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
        }

        user.Guid = GuidExtensions.GetNewGuid();
        user.RecordState = RecordState.Active;

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        context.Users.Add(user);
        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı oluşturulurken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(user.Guid, ActionType.Create, null, user);

        return new ProgressResult(true, "Kullanıcı başarıyla oluşturuldu.");
    }

    public ProgressResult UpdateUser(User user)
    {
        UserValidator userValidator = new(user);
        ProgressResult progressResult = userValidator.Validate();
        if (!progressResult.Result)
        {
            return progressResult;
        }
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Update);
        if (hasPermission != BoolState.True)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı güncelleme yetkiniz yok.");
            return progressResult;
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        User? userOnDb = context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userOnDb == null)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı bulunamadı.");
            return progressResult;
        }

        User? userForLog = context.Users.AsNoTracking().FirstOrDefault(u => u.Id == user.Id);

        userOnDb.Username = user.Username;
        userOnDb.Firstname = user.Firstname;
        userOnDb.Lastname = user.Lastname;
        userOnDb.EMail = user.EMail;
        userOnDb.Phone = user.Phone;
        userOnDb.RecordState = user.RecordState;
        userOnDb.ExpiredAt = user.ExpiredAt;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            progressResult.Result = false;
            progressResult.AddMessage("Kullanıcı güncellenirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog(userOnDb.Guid, ActionType.Update, userForLog, user);
        return new ProgressResult(true, "Kullanıcı başarıyla güncellendi.");
    }

    public ProgressResult DeleteUser(int userId)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Delete);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Kullanıcı silme yetkiniz yok.");
        }
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        User? user = context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new ProgressResult(false, "Kullanıcı bulunamadı.");
        }

        user.RecordState = RecordState.Deleted;

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Kullanıcı silinirken bir hata oluştu.");
        }

        NewtonJsonHelper.SaveLog<User>(user.Guid, ActionType.Delete, null, null);
        return new ProgressResult(true, "Kullanıcı başarıyla silindi.");
    }

    public QueryResult<List<UserView>> GetUsers()
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<UserView>>(false, "Kullanıcıları görüntüleme yetkiniz yok.");
        }

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        List<UserView> userViews = context.Users.Select(u => new UserView
        {
            Id = u.Id,
            Username = u.Username,
            Firstname = u.Firstname,
            Lastname = u.Lastname,
            RecordState = u.RecordState,
            Guid = u.Guid,
            ExpiredAt = u.ExpiredAt,
            EMail = u.EMail,
            Phone = u.Phone
        }).ToList();

        return new QueryResult<List<UserView>>(true, "Kullanıcılar başarıyla getirildi.", userViews);
    }

    public QueryResult<Group> GetGroupByName(string? groupName)
    {
        if (groupName.IsNullOrEmptyOrWhiteSpace())
        {
            return new QueryResult<Group>(false, "Grup adı boş bırakılamaz.");
        }

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        Group? group = context.Groups.AsNoTracking().FirstOrDefault(g => g.Name == groupName);
        if (group == null)
        {
            return new QueryResult<Group>(false, "Grup bulunamadı.");
        }

        return new QueryResult<Group>(true, "Grup başarıyla getirildi.", group);
    }

    public QueryResult<Group> GetGroupById(int groupId, bool includePermissions)
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        Group? group = context.Groups.AsNoTracking().FirstOrDefault(g => g.Id == groupId);
        if (group == null)
        {
            return new QueryResult<Group>(false, "Grup bulunamadı.");
        }

        if (includePermissions)
        {
            group.GroupPermissions = context.GroupPermissions.AsNoTracking().Where(gp => gp.GroupId == groupId).ToList();
        }

        return new QueryResult<Group>(true, "Grup başarıyla getirildi.", group);
    }

    public ProgressResult SaveGroupPermissions(List<GroupPermission> groupGroupPermissions, int groupId)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.AssignedPermissions);
        if (hasPermission != BoolState.True)
        {
            return new ProgressResult(false, "Grup izinlerini ayarlama yetkiniz yok.");
        }

        groupGroupPermissions.ForEach(gp =>
        {
            gp.GroupId = groupId;
        });

        using SandOContext context = new(GlobalVariables.DbContextOptions);

        List<GroupPermission> groupPermissions = context.GroupPermissions.Where(gp => gp.GroupId == groupId).ToList();

        List<GroupPermission> permissions = groupPermissions.Where(g2 => !groupGroupPermissions.Any(g1 =>
                g2.AuthenticationClass == g1.AuthenticationClass && g2.AuthenticationEvent == g1.AuthenticationEvent))
            .ToList();
        context.GroupPermissions.RemoveRange(permissions);

        List<GroupPermission> newGroupPermissions = groupGroupPermissions.Where(g1 => !groupPermissions.Any(g2 =>
                g1.AuthenticationClass == g2.AuthenticationClass && g1.AuthenticationEvent == g2.AuthenticationEvent))
            .ToList();

        foreach (GroupPermission newGroupPermission in newGroupPermissions)
        {
            newGroupPermission.Guid = GuidExtensions.GetNewGuid();
            context.GroupPermissions.Add(newGroupPermission);
        }

        bool saveChanges = context.SaveChangesSafe();
        if (!saveChanges)
        {
            return new ProgressResult(false, "Grup izinleri kaydedilirken bir hata oluştu.");
        }

        foreach (GroupPermission groupPermission in permissions)
        {
            NewtonJsonHelper.SaveLog<GroupPermission>(groupPermission.Guid, ActionType.Delete, null, null);
        }
        foreach (GroupPermission groupPermission in newGroupPermissions)
        {
            NewtonJsonHelper.SaveLog(groupPermission.Guid, ActionType.Create, null, groupPermission);
        }

        Group? firstOrDefault = context.Groups.AsNoTracking().FirstOrDefault(g => g.Id == groupId);
        if (firstOrDefault != null)
            NewtonJsonHelper.SaveLog<Group>(firstOrDefault.Guid, ActionType.PermissionChange, null, null);
        return new ProgressResult(true, "Grup izinleri başarıyla kaydedildi.");
    }

    public QueryResult<User> GetUserById(int userId)
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        User? user = context.Users
            .Include(u => u.UserGroups)
            .Include(u => u.UserDepartments)
            .Include(u => u.DefaultUserDepartment)
            .AsNoTracking().FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new QueryResult<User>(false, "Kullanıcı bulunamadı.");
        }

        if (user.UserGroups != null)
        {
            foreach (UserGroup userGroup in user.UserGroups)
            {
                userGroup.Group = context.Groups.AsNoTracking().FirstOrDefault(g => g.Id == userGroup.GroupId) ?? new Group();
            }
        }

        return new QueryResult<User>(true, "Kullanıcı başarıyla getirildi.", user);
    }

    public QueryResult<List<UserDepartment>> GetUserDepartments(int userId, bool onlyActiveDepartments)
    {
        PermissionManager permissionManager = new();
        BoolState hasPermission = permissionManager.HasPermission(AuthenticationClass.UserGroup, AuthenticationEvent.Read);
        if (hasPermission != BoolState.True)
        {
            return new QueryResult<List<UserDepartment>>(false, "Kullanıcı departmanlarını görüntüleme yetkiniz yok.");
        }

        using SandOContext context = new(GlobalVariables.DbContextOptions);
        IQueryable<UserDepartment> queryable = context.UserDepartments
            .Include(ud => ud.Department)
            .Include(ud => ud.Plant)
            .Include(ud => ud.Company)
            .Include(ud => ud.Appellation)
            .Include(ud => ud.User)
            .Include(ud => ud.CreatedBy)
            .AsNoTracking()
            .Where(ud => ud.UserId == userId);

        if (onlyActiveDepartments)
        {
            queryable = queryable.Where(ud => ud.Department.RecordState == RecordState.Active && ud.EndAt > DateTime.Now);
        }

        List<UserDepartment> userDepartments = queryable.ToList();

        return new QueryResult<List<UserDepartment>>(true, "Kullanıcı departmanları başarıyla getirildi.", userDepartments);
    }
}