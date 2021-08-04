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
   
        public class EssayStudentAnswerConfiguration : IEntityTypeConfiguration<EssayStudentAnswer>
        {
            public void Configure(EntityTypeBuilder<EssayStudentAnswer> builder)
            {
                builder.ToTable("EssayStudentAnswer", Schema.LESSON);

                builder.HasKey(x => new { x.QuestionId, x.StudentId });

            //builder.HasOne<EssayAnswer>(a => a.EssayAnswers)
            //    .WithMany(e => e.EssayStudentAnswers)
            //    .HasForeignKey(a => a.QuestionId)
            //    .HasForeignKey(a => a.StudentId)
            //    .HasForeignKey(a => a.EssayAnswerId);

                builder.HasOne<Question>(x => x.Question)
                    .WithMany(es => es.EssayStudentAnswers)
                    .HasForeignKey(f => f.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(true);

                builder.HasOne<User>(x => x.Student)
                    .WithMany(es => es.EssayStudentAnswers)
                    .HasForeignKey(f => f.StudentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(true);

                builder.HasOne<EssayQuestionAnswer>(x => x.EssayQuestionAnswer)
                   .WithMany(es => es.EssayStudentAnswers)
                   .HasForeignKey(f => f.EssayQuestionAnswerId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(true);

            }
        }
    }

