﻿using Microsoft.EntityFrameworkCore;
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
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-PSI7D8C\SQLEXPRESS;Database=SchoolMaster;User Id=sa;Password=1qaz2wsx@;");
              
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
           
        }
        public DbSet<School> Schools { get; set; }


    }
}
