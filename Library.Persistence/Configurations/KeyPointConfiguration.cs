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
    public class KeyPointConfiguration : IEntityTypeConfiguration<KeyPoint>
    {
        public void Configure(EntityTypeBuilder<KeyPoint> builder)
        {
            builder.HasKey(e => e.KeyPointId);

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.KeyPoints)
                .HasForeignKey(x => x.ResumeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }

}