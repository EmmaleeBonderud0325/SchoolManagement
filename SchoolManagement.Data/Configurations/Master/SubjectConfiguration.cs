using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.SubjectCode);
            builder.HasAlternateKey(x => x.Name);


            builder.HasOne<Subject>(x => x.PerentSubject)
                .WithMany(c => c.ChildBasketSubjects)
                .HasForeignKey(f => f.ParentBasketSubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<SubjectStream>(x => x.SubjectStream)
                .WithMany(s => s.Subjects)
                .HasForeignKey(f => f.SubjectStreamId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<User>(u => u.CreatedBy)
               .WithMany(s => s.CreatedSubjects)
               .HasForeignKey(f => f.CreatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

            builder.HasOne<User>(u => u.UpdatedBy)
               .WithMany(s => s.UpdatedSubjects)
               .HasForeignKey(f => f.UpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);

        }
    }
}
