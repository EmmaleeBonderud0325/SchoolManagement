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
            builder.ToTable("EssayAnswer", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder.HasOne<Question>(x => x.Question)
                .WithMany(ea => ea.EssayAnswers)
                .HasForeignKey(f => f.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

        }
    }
}
