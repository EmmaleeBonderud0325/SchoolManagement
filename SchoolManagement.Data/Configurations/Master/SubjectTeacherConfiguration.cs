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
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.ToTable("SubjectTeacher", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<Subject>(sb => sb.Subject)
               .WithMany(st => st.SubjectTeachers)
               .HasForeignKey(f => f.SubjectId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<AcademicYear>(ay => ay.AcademicYear)
               .WithMany(st => st.SubjectTeachers)
               .HasForeignKey(f => f.AcademicYearId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<AcademicLevel>(al => al.AcademicLevel)
               .WithMany(st => st.SubjectTeachers)
               .HasForeignKey(f => f.AcademicYearId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.Teacher)
                .WithMany(st => st.SubjectTeachers)
                .HasForeignKey(f => f.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(st => st.CreatedSubjectTeachers)
               .HasForeignKey(f => f.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.Teacher)
               .WithMany(st => st.UpdatedSubjectTeachers)
               .HasForeignKey(f => f.UpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);


        }
    }
}
