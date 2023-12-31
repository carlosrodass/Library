﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Configuration
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(x => x.KeyPoints)
                .WithOne(x => x.Resume)
                .HasForeignKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
