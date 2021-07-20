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
    public class LessonAssignmentSubmissionConfiguration : IEntityTypeConfiguration<LessonAssignmentSubmission>
    {
        public void Configure(EntityTypeBuilder<LessonAssignmentSubmission> builder)
        {
            builder.ToTable("LessonAssignmentSubmission", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<LessonAssignment>(x => x.LessonAssignment)
                .WithMany(ls => ls.LessonAssignmentSubmissions)
                .HasForeignKey(f => f.LessonAssignmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.Student)
                .WithMany(ls => ls.LessonAssignmentSubmissions)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


        }
    }
}
