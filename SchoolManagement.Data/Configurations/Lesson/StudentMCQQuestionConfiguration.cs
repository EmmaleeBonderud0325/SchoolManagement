using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model.Account;
using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
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
                .IsRequired(false);

            builder.HasOne<User>(x => x.Student)
                .WithMany(sm => sm.StudentMCQQuestions)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);



            //builder.HasOne<StudentMCQQuestion>(q => q.StudentMCQQuestion)
            //    .WithMany(m => m.MCQStudentAnswers)
            //    .HasForeignKey(f => f.QuestionID)
            //    .HasForeignKey(f => f.StudentID);
        }
    }
}
