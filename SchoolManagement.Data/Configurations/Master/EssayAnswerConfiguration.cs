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
    public class EssayAnswerConfiguration : IEntityTypeConfiguration<EssayAnswer>
    {
        public void Configure(EntityTypeBuilder<EssayAnswer> builder)
        {
            builder.ToTable("EssayAnswer", Schema.MASTER);

            builder.HasKey(x => x.Id);


            builder.HasMany<EssayStudentAnswer>(e => e.EssayStudentAnswers)
                .WithOne(a => a.EssayAnswers)
                .HasForeignKey(a => a.QuestionId)
                  .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


        }
    }
}
