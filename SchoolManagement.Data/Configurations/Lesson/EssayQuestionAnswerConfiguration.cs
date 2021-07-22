using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations
{
    public class EssayQuestionAnswerConfiguration : IEntityTypeConfiguration<EssayQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<EssayQuestionAnswer> builder)
        {
            builder.ToTable("EssayQuestionAnswer", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder.HasOne<Question>(x => x.Question)
                .WithMany(ea => ea.EssayQuestionAnswers)
                .HasForeignKey(f => f.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

        }
    }
}
