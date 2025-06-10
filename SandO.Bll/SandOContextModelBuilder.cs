using Microsoft.EntityFrameworkCore;
using SandO.Entities.Db;

namespace SandO.Bll;

public partial class SandOContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Indexes


        #endregion Indexes

        #region Foreign Keys

        modelBuilder.Entity<Plant>()
            .HasOne(p => p.Company)
            .WithMany(c => c.Plants)
            .HasForeignKey(p => p.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UserGroups)
            .HasForeignKey(ug => ug.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.Group)
            .WithMany(g => g.UserGroups)
            .HasForeignKey(ug => ug.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupPermission>()
            .HasOne(gp => gp.Group)
            .WithMany(g => g.GroupPermissions)
            .HasForeignKey(gp => gp.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasOne(u => u.DefaultUserDepartment)
            .WithMany()
            .HasForeignKey(u => u.DefaultUserDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserDepartment>()
            .HasOne(ud => ud.User)
            .WithMany(u => u.UserDepartments)
            .HasForeignKey(ud => ud.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserDepartment>()
            .HasOne(ud => ud.Company)
            .WithMany(c => c.UserDepartments)
            .HasForeignKey(ud => ud.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserDepartment>()
            .HasOne(ud => ud.Plant)
            .WithMany(p => p.UserDepartments)
            .HasForeignKey(ud => ud.PlantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserDepartment>()
            .HasOne(ud => ud.Department)
            .WithMany(d => d.UserDepartments)
            .HasForeignKey(ud => ud.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserDepartment>()
            .HasOne(ud => ud.Appellation)
            .WithMany(a => a.UserDepartments)
            .HasForeignKey(ud => ud.AppellationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserDepartment>()
            .HasOne(ud => ud.CreatedBy)
            .WithMany(u => u.CreatedByUserDepartments)
            .HasForeignKey(ud => ud.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PermissionFail>()
            .HasOne(pf => pf.User)
            .WithMany(u => u.PermissionFails)
            .HasForeignKey(pf => pf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion Foreign Keys


        base.OnModelCreating(modelBuilder);
    }
}