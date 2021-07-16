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
   
        public class EssayStudentAnswerConfiguration : IEntityTypeConfiguration<EssayStudentAnswer>
        {
            public void Configure(EntityTypeBuilder<EssayStudentAnswer> builder)
            {
                builder.ToTable("EssayStudentAnswer", Schema.MASTER);

                builder.HasKey(x => x.QuestionId);
                builder.HasKey(x => x.StudentId);


                builder.HasOne<EssayAnswer>(a => a.EssayAnswerID)
                    .WithMany(e => e.EssayStudentAnswers)
                     .HasForeignKey(a => a.QuestionId)
                      .HasForeignKey(a => a.StudentId)
                       .HasForeignKey(a => a.EssayAnswerId);
            }
        }
    }

