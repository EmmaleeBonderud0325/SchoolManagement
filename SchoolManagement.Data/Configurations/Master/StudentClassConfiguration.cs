using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class StudentClassConfiguration : IEntityTypeConfiguration<StudentClass>
    {
        public void Configure(EntityTypeBuilder<StudentClass> builder)
        {
            builder.ToTable("StudentClass", Schema.MASTER);

            builder.HasKey(x => new { x.StudentId, x.ClassNameId, x.AcademicLevelId, x.AcademicYearId });

            builder.HasOne<Student>(s => s.Student)
                .WithMany(sc => sc.StudentClasses)
                .HasForeignKey(fk => fk.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<Class>(cl => cl.Class)
                .WithMany(sc => sc.StudentClasses)
                .HasForeignKey(fk => new {fk.ClassNameId, fk.AcademicLevelId, fk.AcademicYearId})
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
