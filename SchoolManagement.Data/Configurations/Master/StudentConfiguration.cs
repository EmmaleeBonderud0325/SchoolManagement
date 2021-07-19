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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", Schema.MASTER);

            builder.HasKey(x => x.ID);

            //to be implement foriegn key
            /*builder.HasOne(st => st.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(fk => fk.ID);
            */
            builder.HasOne<User>(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(fk => fk.ID);
                
        }
    }
}
