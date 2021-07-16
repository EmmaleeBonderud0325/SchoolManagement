using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class", Schema.MASTER);

            builder.HasKey(x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId });

            builder.HasOne<ClassName>(cn => cn.ClassName)
             .WithMany(cl => cl.Class)
             .HasForeignKey(f => f.ClassNameId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);

            builder.HasOne<AcademicLevel>(al => al.AcademicLevel)
             .WithMany(cl => cl.Class)
             .HasForeignKey(f => f.AcademicLevelId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);

            builder.HasOne<AcademicYear>(ay => ay.AcademicYear)
             .WithMany(cl => cl.Class)
             .HasForeignKey(f => f.AcademicYearId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);
        }
    }
}
