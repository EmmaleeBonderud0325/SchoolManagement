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
    public class TopicContentConfiguration : IEntityTypeConfiguration<TopicContent>
    {
        public void Configure(EntityTypeBuilder<TopicContent> builder)
        {
            builder.ToTable("TopicContent", Schema.MASTER);
            builder.HasKey(x => x.ID);

            builder.HasOne<Topic>(ti =>ti.TopicContents)
                .WithOne(t => t.Topics)
                .HasForeignKey(ti => ti.TopicId);


        }
    }
