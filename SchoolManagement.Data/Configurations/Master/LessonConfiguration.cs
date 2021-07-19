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
            builder.ToTable("Lesson", Schema.MASTER);
            builder.HasKey(x => x.ID);

            builder.HasOne<Lesson>(l => l.Lesson)
                  .WithMany(t => t.Topics)
                  .HasForeignKey(l => l.AcademicLevelID)
                  .HasForeignKey(l => l.ClassNameId)
                  .HasForeignKey(l => l.AcademicYearId)
                  .HasForeignKey(l => l.SubjectId);



        }
    }
}
