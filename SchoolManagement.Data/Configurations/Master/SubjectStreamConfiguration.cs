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
    public class SubjectStreamConfiguration : IEntityTypeConfiguration<SubjectStream>
    {
        public void Configure(EntityTypeBuilder<SubjectStream> builder)
        {
            builder.ToTable("SubjectStream", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<User>(x => x.CreatedBy)
                .WithMany(u => u.CreatedSubjectStreams)
                .HasForeignKey(f => f.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            builder.HasOne<User>(x => x.UpdatedBy)
               .WithMany(u => u.UpdatedSubjectStreams)
               .HasForeignKey(f => f.UpdatedById)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(true);
        }
    }
}
