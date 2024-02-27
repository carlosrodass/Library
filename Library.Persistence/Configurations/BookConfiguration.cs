using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(x => x.BookId);

            builder.HasOne(x => x.Resume)
                .WithOne(x => x.Book)
                .HasForeignKey<Resume>(e => e.ResumeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
