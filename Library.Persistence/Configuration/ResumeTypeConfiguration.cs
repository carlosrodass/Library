using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Configuration
{
    public class ResumeTypeConfiguration : IEntityTypeConfiguration<ResumeType>
    {
        public void Configure(EntityTypeBuilder<ResumeType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                ResumeType.List()
                );
        }
    }
}
