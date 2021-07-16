using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model.Master;
using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class ClassNameConfiguration : IEntityTypeConfiguration<ClassName>
    {
        public void Configure(EntityTypeBuilder<ClassName> builder)
        {
            builder.ToTable("ClassName", Schema.MASTER);

            builder.HasKey(x => new { x.Id, x.CreatedById, x.UpdatedById });

            builder.HasOne<User>(u => u.User)
             .WithMany(cn => cn.ClassName)
             .HasForeignKey(f => f.CreatedById)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);

            builder.HasOne<User>(u => u.User)
             .WithMany(cn => cn.ClassName)
             .HasForeignKey(f => f.UpdatedById)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);
        }
    }
}
