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
               .IsRequired(true);

            builder.HasOne<Subject>(sb => sb.Subject)
               .WithMany(c => c.ClassSubjectTeachers)
               .HasForeignKey(f => f.SubjectId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<Class>(c => c.Class)
               .WithMany(cs => cs.ClassSubjectTeachers)
               .HasForeignKey(f => new {f.ClassNameId, f.AcademicLevelId, f.AcademicYearId})
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(c => c.CreatedClassSubjectTeachers)
               .HasForeignKey(f => f.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.UpdatedBy)
               .WithMany(c => c.UpdatedClassSubjectTeachers)
               .HasForeignKey(f => f.UpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);



        }
    }
}
