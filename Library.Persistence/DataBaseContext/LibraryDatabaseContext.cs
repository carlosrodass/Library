using Library.Domain;
using Library.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.DataBaseContext
{
    public class LibraryDatabaseContext : DbContext
    {

        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Library.Domain.Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<KeyPoint> KeyPoints { get; set; }
        public DbSet<LibraryBook> LibraryBooks { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ResumeType> ResumeTypes { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                    .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
