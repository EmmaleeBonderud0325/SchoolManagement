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
    public class ClassTeacherConfiguration : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> builder)
        {
            builder.ToTable("ClassTeacher", Schema.MASTER);

            builder.HasKey(x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId, x.TeacherId });

            builder.HasOne<Class>(c => c.Class)
             .WithMany(ct => ct.ClassTeachers)
             .HasForeignKey(f => f.ClassNameId)
             .HasForeignKey(f => f.AcademicLevelId)
             .HasForeignKey(f => f.AcademicYearId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);

            builder.HasOne<User>(u => u.CreatedBy)
             .WithMany(ct => ct.CreatedClassTeachers)
             .HasForeignKey(f => f.CreatedById)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);

            builder.HasOne<User>(u => u.UpdatedBy)
             .WithMany(ct => ct.UpdatedClassTeachers)
             .HasForeignKey(f => f.UpdatedById)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);
        }
    }
}
