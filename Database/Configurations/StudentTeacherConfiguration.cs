using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Database.Entities;

namespace School.Database.Configurations
{
    public class StudentTeacherConfiguration : IEntityTypeConfiguration<StudentTeacher>
    {
        public void Configure(EntityTypeBuilder<StudentTeacher> builder)
        {
            builder.HasKey(m => new { m.StudentGUID, m.TeacherGUID });
            builder.HasIndex(m => m.TeacherGUID);
            builder
                .HasOne(m => m.Student)
                .WithMany(m => m.StudentTeacher)
                .HasForeignKey(m => m.StudentGUID);
            builder
                .HasOne(m => m.Teacher)
                .WithMany(m => m.StudentTeacher)
                .HasForeignKey(m => m.TeacherGUID);
        }
    }
}