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
    public class HeadOfDepartmentConfiguration : IEntityTypeConfiguration<HeadOfDepartment>
    {
        public void Configure(EntityTypeBuilder<HeadOfDepartment> builder)
        {
            builder.ToTable("HeadOfDepartment", Schema.MASTER);

            builder.HasKey(x => new { x.SubjectId, x.AcademicLevelId, x.AcademicYearId, x.TeacherId });

            builder.HasOne<Subject>(sb => sb.Subject)
                .WithMany(hod => hod.HeadOfDepartments)
                .HasForeignKey(fk => fk.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<AcademicLevel>(al => al.AcademicLevel)
                .WithMany(hod => hod.HeadOfDepartments)
                .HasForeignKey(fk => fk.AcademicLevelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<AcademicYear>(ay => ay.AcademicYear)
                .WithMany(hod => hod.HeadOfDepartments)
                .HasForeignKey(fk => fk.AcademicYearId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<SubjectTeacher>(st => st.SubjectTeacher)
                .WithMany(hod => hod.HeadOfDepartments)
                .HasForeignKey(fk => fk.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
