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

            builder.HasMany(x => x.Resumes)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.ResumeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
