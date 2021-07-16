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
    public class AssessmentTypeConfiguration : IEntityTypeConfiguration<EssayStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<EssayStudentAnswer> builder)
        {
            builder.ToTable("AssessmentType", Schema.MASTER);

            builder.HasKey(x => x.AssessmentTypeId);


            _ = builder.HasMany<AcademicLevelAssessmentType>(ac => ac.AcademicLevelAssesmentType)
                .WithOne(a => a.AssessmentType)
                 .HasForeignKey(ac => ac.UpdatedById)
                  .HasForeignKey(ac => ac.CreatedById);
        }
    }
}
