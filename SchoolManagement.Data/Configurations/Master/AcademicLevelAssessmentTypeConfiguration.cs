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
    public class AcademicLevelAssessmentTypeConfiguration : IEntityTypeConfiguration<AcademicLevelAssessmentType>
    {
        public void Configure(EntityTypeBuilder<AcademicLevelAssessmentType> builder)
        {
            builder.ToTable("AcademicLevelAssessmentType", Schema.MASTER);

            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.AcademicLevelId);

            builder.HasOne<AssessmentType>(a => a.AssessmentTypes)
                .WithMany(ac => ac.AcademicLevelAssessmentTypes)
                .HasForeignKey(a  => a.AcademicLevelId)
                .HasForeignKey(a => a.Id)
                 .HasForeignKey(a => a.UpdatedById)
                  .HasForeignKey(a => a.CreatedById);
        }
    }
}
