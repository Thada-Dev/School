using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Database.Entities;

namespace School.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(m => m.StudentGUID);
            builder
                .HasOne(m => m.Home)
                .WithOne(m => m.Student)
                .HasForeignKey<Home>(m => m.StudentGUID);
        }
    }
}