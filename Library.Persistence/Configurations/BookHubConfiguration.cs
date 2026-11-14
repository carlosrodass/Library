using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Domain.Models;

namespace MyLibrary.Persistence.Configuration
{
    public class BookHubConfiguration : IEntityTypeConfiguration<BookHub>
    {
        public void Configure(EntityTypeBuilder<BookHub> builder)
        {

            builder.HasKey(bh => new { bh.BookId, bh.HubId });

        }
    }
}
