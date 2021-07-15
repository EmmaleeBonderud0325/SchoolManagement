using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class ClassNameConfiguration : IEntityTypeConfiguration<ClassName>
    {
        public void Configure(EntityTypeBuilder<ClassName> builder)
        {
            builder.ToTable("ClassName", Schema.MASTER);

            builder.HasKey(x => x.Id);

        }
    }
}
