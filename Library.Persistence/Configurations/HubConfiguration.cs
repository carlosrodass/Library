using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Configurations
{
    public class HubConfiguration : IEntityTypeConfiguration<Hub>
    {
        public void Configure(EntityTypeBuilder<Hub> builder)
        {
            builder.HasKey(x => x.HubId);

            builder.HasMany(h => h.Books)
                   .WithMany(h => h.Hubs)
                   .UsingEntity<BookHub>(
                    j => j
                        .HasOne(bh => bh.Book)
                        .WithMany(b => b.BookHubs)
                        .HasForeignKey(bh => bh.BookId)
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne(bh => bh.Hub)
                        .WithMany(h => h.BookHubs)
                        .HasForeignKey(bh => bh.HubId)
                        .OnDelete(DeleteBehavior.Restrict)
                        );

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
