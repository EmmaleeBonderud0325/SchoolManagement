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
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.ToTable("SubjectTeacher", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<Subject>(sb => sb.Subject)
             .WithMany(st => st.SubjectTeachers)
             .HasForeignKey(f => f.SubjectId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired(false);


        }
    }
}
