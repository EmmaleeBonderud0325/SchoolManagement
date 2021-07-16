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
    public class AcademicLevelAssessmentTypeConfiguration : IEntityTypeConfiguration<AcademicLevelAssessmentType>
    {
        public void Configure(EntityTypeBuilder<AcademicLevelAssessmentType> builder)
        {
            builder.ToTable("AcademicLevelAssessmentType", Schema.MASTER);

            builder.HasKey(x => x.AssessmentTypeId);
            builder.HasKey(x => x.AcademicLevelId);

            builder.HasOne<EssayStudentAnswer>(a => a.AssessmentType)
                .WithMany(ac => ac.AcademicLevelAssesmentType)
                .HasForeignKey(a  => a.AcademicLevelID)
                .HasForeignKey(a => a.AssessmentTypeID)
                 .HasForeignKey(a => a.UpdatedByID)
                  .HasForeignKey(a => a.CreatedByID);
        }
    }
}
