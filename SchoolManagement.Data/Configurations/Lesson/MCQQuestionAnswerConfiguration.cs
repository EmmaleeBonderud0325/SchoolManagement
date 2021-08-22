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
    public class MCQQuestionAnswerConfiguration : IEntityTypeConfiguration<MCQQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<MCQQuestionAnswer> builder)
        {
            builder.ToTable("MCQQuestionAnswer", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder.HasOne<Question>(q=>q.Question)
                .WithMany(m=>m.MCQQuestionAnswers)
                .HasForeignKey(f=>f.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            //builder.HasOne<Question>(q => q.Question)
            //    .WithMany(ma => ma.MCQAnswers)
            //    .HasForeignKey(f => f.QuestionID);
        }
    }
}
