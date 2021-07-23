using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model;
using SchoolManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Account
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", Schema.ACCOUNT);

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasOne<Student>(s => s.Student)
                .WithOne(u => u.User)
                .HasForeignKey<Student>(f => f.Id);

            builder.HasOne<User>(u => u.CreatedBy)
                .WithMany(c => c.CreatedUsers)
                .HasForeignKey(f => f.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(u => u.UpdatedBy)
                .WithMany(c => c.UpdatedUsers)
                .HasForeignKey(f => f.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            var superAdmin = new User()
            {
                Id = 1,
                FullName = "SuperAdmin",
               
                Email = "avdunusinghe@gmail.com",
                Username = "avdunusinghe@gmail.com",
                MobileNo = "0703375581",
                Password = CustomPasswordHasher.GenerateHash("pass@123!"),
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            var admin = new User()
            {
                Id = 2,
                FullName = "Admin",
                Email = "admin@gmail.com",
                Username = "admin@gmail.com",
                MobileNo = "0112487086",
                Password = CustomPasswordHasher.GenerateHash("pass@123!"),
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            builder.HasData(superAdmin, admin);

        }
    }
}
