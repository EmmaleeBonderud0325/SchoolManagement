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
    public class StudentMCQQuestionConfiguration : IEntityTypeConfiguration<StudentMCQQuestion>
    {
        public void Configure(EntityTypeBuilder<StudentMCQQuestion> builder)
        {
            builder.ToTable("StudentMCQQuestion", Schema.Master);

            builder.HasKey(x => x.QuestionID);
            builder.HasKey(x => x.StudentID);

            builder.HasOne<StudentMCQQuestion>(q => q.StudentMCQQuestion)
                .WithMany(m => m.MCQStudentAnswers)
                .HasForeignKey(f => f.QuestionID)
                .HasForeignKey(f => f.StudentID);
        }
    }
