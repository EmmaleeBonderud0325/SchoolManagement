using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Master.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Master.Data.Configuration
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("School");

            builder.HasKey(x => x.Id);

            builder.Property(t => t.TenantId).HasDefaultValue(Guid.NewGuid());

            builder.Property(a => a.APIKey).HasDefaultValue(Guid.NewGuid());

            builder.Property(s => s.SecretKey).HasDefaultValue(Guid.NewGuid());
        }
    }
}
