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
    public class MCQQuestionStudentAnswerConfiguration : IEntityTypeConfiguration<MCQQuestionStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<MCQQuestionStudentAnswer> builder)
        {
            builder.ToTable("MCQQuestionStudentAnswer", Schema.LESSON);

            builder.HasKey(x => new { x.QuestionId, x.StudentId });

            builder.HasOne<Question>(x => x.Question)
                .WithMany(ms => ms.MCQQuestionStudentAnswers)
                .HasForeignKey(f => f.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);


            builder.HasOne<Student>(x => x.Student)
                .WithMany(ms => ms.MCQQuestionStudentAnswers)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);


            //builder.HasMany<MCQStudentAnswer>(q => q.MCQStudentAnswer)
            //    .WithOne(ma => ma.MCQAnswer)
            //    .HasForeignKey(q => q.QuestionID);
        }
    }
}
