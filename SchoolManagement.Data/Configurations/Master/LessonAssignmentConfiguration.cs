﻿using Microsoft.EntityFrameworkCore;
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
    class LessonAssignmentConfiguration : IEntityTypeConfiguration<LessonAssignment>
    {
        public void Configure(EntityTypeBuilder<LessonAssignment> builder)
        {
            builder.ToTable("LessonAssignment", Schema.MASTER);

            builder.HasKey(x => x.Id);

            builder.HasOne<Lesson>(x => x.Lesson)
                .WithMany(la => la.LessonAssignments)
                .HasForeignKey(f => f.LessonId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.CreatedBy)
                .WithMany(la => la.CreatedLessonAssignments)
                .HasForeignKey(f => f.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne<User>(x => x.UpdatedBy)
                .WithMany(la => la.UpdatedLessonAssignments)
                .HasForeignKey(f => f.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


        }
    }
}
