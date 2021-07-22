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
    public class TopicContentConfiguration : IEntityTypeConfiguration<TopicContent>
    {
        public void Configure(EntityTypeBuilder<TopicContent> builder)
        {
            builder.ToTable("TopicContent", Schema.LESSON);

            builder.HasKey(x => x.Id);

            builder.HasOne<Topic>(x=>x.Topic)
                .WithMany(tc=>tc.TopicContents)
                .HasForeignKey(f=>f.TopicId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

        }
    }
}
