using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model.Account;
using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<User>(u => u.User)
               .WithMany(s => s.Subjects)
               .HasForeignKey(f => f.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

            builder.HasOne<User>(u => u.User)
               .WithMany(s => s.Subjects)
               .HasForeignKey(f => f.UpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

        }
    }
}
