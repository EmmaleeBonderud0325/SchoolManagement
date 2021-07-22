using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configuration.Master
{
    public class StudentLessonConfiguration : IEntityTypeConfiguration<StudentLesson>
    {
        public void Configure(EntityTypeBuilder<StudentLesson> builder)
        {
            builder.ToTable("StudentLesson", Schema.LESSON);

            builder.HasKey(x => new { x.LessonId, x.StudentId });

            builder.HasOne<Lesson>(l => l.Lesson)
                .WithMany(sl => sl.StudentLessons)
                .HasForeignKey(f => f.LessonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<Student>(s => s.Student)
                .WithMany(sl => sl.StudentLessons)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

        }

        
    }
}
