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
    public class ClassSubjectTeacherConfiguration : IEntityTypeConfiguration<ClassSubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassSubjectTeacher> builder)
        {
            builder.ToTable("ClassSubjectTeacher", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<SubjectTeacher>(st => st.SubjectTeacher)
              .WithMany(c => c.ClassSubjectTeachers)
              .HasForeignKey(f => f.SubjectTeacherId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired(false);

            builder.HasOne<Subject>(sb => sb.Subject)
             .WithMany(c => c.ClassSubjectTeachers)
             .HasForeignKey(f => f.SubjectId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);

            builder.HasOne<Class>(c => c.Class)
             .WithMany(cs => cs.ClassSubjectTeachers)
             .HasForeignKey(f => f.ClassNameId)
             .HasForeignKey(f => f.AcademicLevelId)
             .HasForeignKey(f => f.AcademicYearId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);




        }
    }
}
