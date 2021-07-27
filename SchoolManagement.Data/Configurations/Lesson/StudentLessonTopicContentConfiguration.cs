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
    public class StudentLessonTopicContentConfiguration : IEntityTypeConfiguration<StudentLessonTopicContent>
    {
        public void Configure(EntityTypeBuilder<StudentLessonTopicContent> builder)
        {
            builder.ToTable("StudentLessonTopicContenet", Schema.LESSON);

            builder.HasKey(x => new { x.TopicContentId, x.StudentId });

            builder.HasOne<TopicContent>(x => x.TopicContent)
                .WithMany(slt => slt.StudentLessonTopicContents)
                .HasForeignKey(f => f.TopicContentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<Student>(x => x.Student)
                .WithMany(slt => slt.StudentLessonTopicContents)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
        }
    }
}
