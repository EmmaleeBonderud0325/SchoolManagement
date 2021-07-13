using Microsoft.EntityFrameworkCore;
using SchoolManagement.Master.Data.Configuration;
using SchoolManagement.Master.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Master.Data.Data
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext()
        {

        }
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=LAPTOP-JE21CP1B\SQLEXPRESS;Database=SchoolMaster;User Id=av;Password=1qaz2wsx@;");
                //optionsBuilder.UseSqlServer(@"Server=LAPTOP-2UJGULUH\SQLEXPRESS;Database=SchoolMaster;User Id=hp;Password=1qaz2wsx@;");
                //optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=SchoolMaster;User Id=ra;Password=1qaz2wsx@;");
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-33VQTC5\SQLEXPRESS;Database=SchoolMaster;User Id=cg;Password=1qaz2wsx@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
           
        }
        public DbSet<School> Schools { get; set; }


    }
}
