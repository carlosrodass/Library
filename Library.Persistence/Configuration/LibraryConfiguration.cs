using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Configuration
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library.Domain.Library>
    {
        public void Configure(EntityTypeBuilder<Domain.Library> builder)
        {
            //This is an example of how to seed database table
            //builder.HasData(
            //        new Library.Domain.Library
            //        {
            //            Id = 1,
            //            Name = "Vacation",
            //            Description = "Library for book readed on vacations",
            //            DateCreated = DateTime.Now,
            //            DateModified = DateTime.Now,
            //        });

            //This is an example of how to add validation rules at DB level
            //builder.Property(q => q.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //Here you also define the relations beetween to entities rather be One-To-Many , One-To-One..
        }

    }
}
