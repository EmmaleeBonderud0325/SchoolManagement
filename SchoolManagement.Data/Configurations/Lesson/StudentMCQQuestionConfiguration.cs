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
    public class StudentMCQQuestionConfiguration : IEntityTypeConfiguration<StudentMCQQuestion>
    {
        public void Configure(EntityTypeBuilder<StudentMCQQuestion> builder)
        {
            builder.ToTable("StudentMCQQuestion", Schema.LESSON);

            builder.HasKey(x => new { x.QuestionId, x.StudentId });

            builder.HasOne<Question>(x=>x.Question)
                .WithMany(sm => sm.StudentMCQQuestions)
                .HasForeignKey(f => f.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<Student>(x => x.Student)
                .WithMany(sm => sm.StudentMCQQuestions)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);



            //builder.HasOne<StudentMCQQuestion>(q => q.StudentMCQQuestion)
            //    .WithMany(m => m.MCQStudentAnswers)
            //    .HasForeignKey(f => f.QuestionID)
            //    .HasForeignKey(f => f.StudentID);
        }
    }
}
