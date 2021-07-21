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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question", Schema.Master);

            builder.HasKey(x => x.Id);

            builder.HasOne<Lesson>(l=>l.Lesson)
                .WithMany(q=>q.Questions)
                .HasForeignKey(f=>f.LessonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


            builder.HasOne<Topic>(t=>t.Topic)
                .WithMany(q=>q.Questions)
                .HasForeignKey(f=>f.TopicId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            //builder.HasMany<MCQAnswer>(ma => ma.MCQAnswers)
            //    .WithOne(q => q.Question)
            //    .HasForeignKey(q => q.TopicID)
            //    .HasForeignKey(q => q.LessonID);

            /*  builder.HasOne<MCQAnswer>(ma=>ma.Question)
                  .WithMany(m=>m.)*/

        }
    }
}
