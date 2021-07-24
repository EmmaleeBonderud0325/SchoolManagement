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
    //public class AssessmentTypeConfiguration : IEntityTypeConfiguration<AssessmentType>
    //{
    //    public void Configure(EntityTypeBuilder<AssessmentType> builder)
    //    {
    //        builder.ToTable("AssessmentType", Schema.MASTER);

    //        builder.HasKey(x => x.Id);


    //        builder.HasMany<AcademicLevelAssessmentType>(ac => ac.AcademicLevelAssessmentTypes)
    //            .WithOne(a => a.AssessmentTypes)
    //             .HasForeignKey(ac => ac.UpdatedById)
    //              .HasForeignKey(ac => ac.CreatedById);
    //    }
    //}
}
