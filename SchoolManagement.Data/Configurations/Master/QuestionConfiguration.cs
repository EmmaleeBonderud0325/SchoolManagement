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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question", Schema.Master);

            builder.HasKey(x => x.QuestionID);

            builder.HasMany<MCQAnswer>(q => q.MCQAnswers)
                .WithOne(m => m.Question)
                .HasForeignKey(f => f.TopicID)
                .HasForeignKey(f => f.LessonID);
        }
    }
}
