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
    public class StudentClassConfiguration : IEntityTypeConfiguration<StudentClass>
    {
        public void Configure(EntityTypeBuilder<StudentClass> builder)
        {
            builder.ToTable("StudentClass", Schema.MASTER);

            builder.HasKey(x => new { x.StudentId, x.ClassNameId, x.AcademicLevelId, x.AcademicYearId });

            builder.HasOne<Student>(s => s.Student)
                .WithMany(sc => sc.StudentClasses) //icollection
                .HasForeignKey(fk => fk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Class>(cl => cl.Class)
                .WithMany(sc => sc.StudentClasses)
                .HasForeignKey(fk => fk.ClassNameId)
                .HasForeignKey(fk => fk.AcademicLevelId)
                .HasForeignKey(fk => fk.AcademicYearId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
