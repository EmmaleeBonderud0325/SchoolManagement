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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder.HasOne<Class>(x => x.Class)
                .WithMany(l => l.Lessons)
                .HasForeignKey(f => new { f.AcademicLevelId, f.ClassNameId, f.AcademicYearId })
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<Subject>(x => x.Subject)
                .WithMany(l => l.Lessons)
                .HasForeignKey(f => f.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.Owner)
                .WithMany(lo => lo.OwnerLessons)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.CreatedBy)
                .WithMany(u => u.CreatedLessons)
                .HasForeignKey(f => f.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.UpdatedBy)
                .WithMany(u => u.CreatedLessons)
                .HasForeignKey(f => f.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

        }
    }
}
