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
    public class LibraryBooksConfiguration : IEntityTypeConfiguration<LibraryBook>
    {
        public void Configure(EntityTypeBuilder<LibraryBook> builder)
        {
            builder
            .HasKey(lb => new { lb.Id });

            builder
                .HasOne(lb => lb.Library)
                .WithMany(l => l.LibraryBooks)
                .HasForeignKey(lb => lb.LibraryId)
                .OnDelete(DeleteBehavior.Restrict); // Especifica ON DELETE NO ACTION

            builder
                .HasOne(lb => lb.Book)
                .WithMany(b => b.LibraryBooks)
                .HasForeignKey(lb => lb.BookId)
                .OnDelete(DeleteBehavior.Restrict); // Especifica ON DELETE NO ACTION
        }
    }
}
