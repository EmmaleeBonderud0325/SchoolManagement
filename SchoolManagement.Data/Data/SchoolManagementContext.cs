using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Configurations.Account;
using SchoolManagement.Model.Account;
using SchoolManagement.Util.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Data
{
    public class SchoolManagementContext : DbContext
    {
        private TenantSchool tenantSchool;
        public SchoolManagementContext()
        {

        }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options, ITenantProvider tenantProvider) : base(options)
        {
            GetTenant(tenantProvider).Wait();
        }
        private async Task GetTenant(ITenantProvider tenantProvider)
        {
            tenantSchool = await tenantProvider.GetTenant();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(tenantSchool != null)
            {
                optionsBuilder.UseSqlServer(tenantSchool.ConnectionString);
            }

            else if(tenantSchool == null && !optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer(@"Server=LAPTOP-JE21CP1B\SQLEXPRESS;Database=SchoolManagment;User Id=av;Password=1qaz2wsx@;");
                //optionsBuilder.UseSqlServer(@"Server=LAPTOP-2UJGULUH\SQLEXPRESS;Database=SchoolManagment;User Id=hp;Password=1qaz2wsx@;");
                optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=SchoolManagment;User Id=ra;Password=1qaz2wsx@;");
            }
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }




    }
}
