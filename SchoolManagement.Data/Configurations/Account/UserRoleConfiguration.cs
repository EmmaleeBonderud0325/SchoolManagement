using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Account
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", Schema.ACCOUNT);

            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne<User>(u => u.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Role>(r => r.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(f => f.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(c => c.CreatedUserRoles)
               .HasForeignKey(f => f.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.UpdatedBy)
                .WithMany(c => c.UpdatedUserRoles)
                .HasForeignKey(f => f.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            var superAdminRole = new UserRole()
            {
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActive = true,
                RoleId = 1,
                UserId = 1,
                UpdatedById = 1,
                CreatedById = 1,
            };
            var adminRole = new UserRole()
            {
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActive = true,
                RoleId = 2,
                UserId = 2,
                UpdatedById = 1,
                CreatedById = 1,
            };

            builder.HasData(superAdminRole, adminRole);
        }
    }
}
