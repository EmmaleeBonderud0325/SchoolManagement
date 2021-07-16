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
    public class MCQAnswerConfiguration : IEntityTypeConfiguration<MCQStudentAnswer>
    {
        public void Configure(EntityTypeBuilder<MCQStudentAnswer> builder)
        {
            builder.ToTable("MCQStudentAnswer", Schema.Master);

            builder.HasKey(x => x.QuestionID);
            builder.HasKey(x => x.StudentID);

            builder.HasMany<MCQStudentAnswer>(q => q.MCQStudentAnswer)
                .WithOne(ma => ma.MCQAnswer)
                .HasForeignKey(q => q.QuestionID);
        }
    }
}
