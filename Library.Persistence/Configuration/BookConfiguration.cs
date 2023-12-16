using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.Resumes)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
