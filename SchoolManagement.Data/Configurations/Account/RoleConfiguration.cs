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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", Schema.ACCOUNT);

            builder.HasKey(x => x.Id);

            var superAdmin = new Role()
            {
                Id = 1,
                IsActive = true,
                Name = "SuperAdmin"              
            };

            var admin = new Role()
            {
                Id = 2,              
                IsActive = true,               
                Name = "Admin"                
            };

            var principle = new Role()
            {
                Id = 3,               
                IsActive = true,               
                Name = "Principle"              
            };

            var levelHead = new Role()
            {
                Id = 4,             
                IsActive = true,              
                Name = "LevelHead"                
            };

            var hod = new Role()
            {
                Id = 5,             
                IsActive = true,               
                Name = "HOD"              
            };

            var teacher = new Role()
            {
                Id = 6,              
                IsActive = true,                
                Name = "Teacher"               
            };

            var student = new Role()
            {
                Id = 7,          
                IsActive = true,               
                Name = "Student"                
            };

            var parent = new Role()
            {
                Id = 8,               
                IsActive = true,               
                Name = "Parent"               
            };

            builder.HasData(superAdmin, admin, principle, levelHead, hod, teacher, student, parent);
        }

    }
}
