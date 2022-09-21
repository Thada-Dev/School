using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Database.Entities;

namespace School.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(m => m.BookGUID);
            builder
                .HasOne(m => m.Student)
                .WithMany(m => m.Book)
                .HasForeignKey(m => m.StudentGUID);
        }
    }
}