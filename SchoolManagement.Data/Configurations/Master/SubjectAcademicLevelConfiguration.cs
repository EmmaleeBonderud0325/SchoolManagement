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
    public class SubjectAcademicLevelConfiguration : IEntityTypeConfiguration<SubjectAcademicLevel>
    {
        public void Configure(EntityTypeBuilder<SubjectAcademicLevel> builder)
        {
            builder.ToTable("SubjectAcademicLevel", Schema.MASTER);

            builder.HasKey(x => new { x.SubjectId, x.AcademicLevelId });

            builder.HasOne<Subject>(s => s.Subject)
               .WithMany(a => a.SubjectAcademicLevels)
               .HasForeignKey(f => f.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<AcademicLevel>(a => a.AcademicLevel)
               .WithMany(a => a.SubjectAcademicLevels)
               .HasForeignKey(f => f.AcademicLevelId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
