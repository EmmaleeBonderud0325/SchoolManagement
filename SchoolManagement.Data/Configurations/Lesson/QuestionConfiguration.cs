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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder.HasOne<Lesson>(l=>l.Lesson)
                .WithMany(q=>q.Questions)
                .HasForeignKey(f=>f.LessonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);


            builder.HasOne<Topic>(t=>t.Topic)
                .WithMany(q=>q.Questions)
                .HasForeignKey(f=>f.TopicId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.CreatedBy)
               .WithMany(u => u.CreatedQuestions)
               .HasForeignKey(f => f.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(x => x.UpdatedBy)
                .WithMany(u => u.UpdatedQuestions)
                .HasForeignKey(f => f.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            //builder.HasMany<MCQAnswer>(ma => ma.MCQAnswers)
            //    .WithOne(q => q.Question)
            //    .HasForeignKey(q => q.TopicID)
            //    .HasForeignKey(q => q.LessonID);

            /*  builder.HasOne<MCQAnswer>(ma=>ma.Question)
                  .WithMany(m=>m.)*/

        }
    }
}
