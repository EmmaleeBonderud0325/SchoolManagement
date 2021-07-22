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
    public class StudentLessonTopicConfiguration : IEntityTypeConfiguration<StudentLessonTopic>
    {
        public void Configure(EntityTypeBuilder<StudentLessonTopic> builder)
        {
            builder.ToTable("StudentLessonTopic", Schema.LESSON);

            builder.HasKey(x => new { x.TopicId, x.StudentId });

            builder.HasOne<Topic>(x => x.Topic)
                .WithMany(x => x.StudentLessonTopics)
                .HasForeignKey(f => f.TopicId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<Student>(x=>x.Student)
                .WithMany(x=>x.StudentLessonTopics)
                .HasForeignKey(f=>f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
