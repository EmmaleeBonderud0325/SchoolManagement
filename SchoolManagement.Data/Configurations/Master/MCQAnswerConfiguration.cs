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
    public class MCQAnswerConfiguration : IEntityTypeConfiguration<MCQAnswer>
    {
        public void Configure(EntityTypeBuilder<MCQAnswer> builder)
        {
            builder.ToTable("MCQAnswer", Schema.Master);

            builder.HasKey(x => x.StudentID);

            builder.HasOne<Question>(q => q.Question)
                .WithMany(ma => ma.MCQAnswers)
                .HasForeignKey(f => f.QuestionID);
        }
    }
}
