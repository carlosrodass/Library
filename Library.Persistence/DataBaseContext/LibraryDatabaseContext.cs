using Microsoft.EntityFrameworkCore;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.DataBaseContext
{
    public class LibraryDatabaseContext : DbContext
    {

        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
        {


        }

        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<KeyPoint> KeyPoints { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ResumeType> ResumeTypes { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDatabaseContext).Assembly); //Buscando si hay configuraciones en la carpeta Configurations
            //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration()); //Forma de configurar Entidad por entidad
            base.OnModelCreating(modelBuilder);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{

        //    foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
        //            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        //    {
        //        entry.Entity.DateModified = DateTime.Now;

        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.DateCreated = DateTime.Now;
        //        }

        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    //{
        //    //    var isActiveProperty = entityType.FindProperty("IsDeleted");

        //    //    if (isActiveProperty != null)
        //    //    {
        //    //        var parameter = Expression.Parameter(entityType.ClrType);
        //    //        var property = Expression.Property(parameter, "IsDeleted");
        //    //        var filterExpression = Expression.Equal(property, Expression.Constant(false));

        //    //        var lambda = Expression.Lambda(filterExpression, parameter);

        //    //        modelBuilder.Entity(entityType.ClrType)
        //    //            .HasQueryFilter(lambda);
        //    //    }
        //    //}

        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDatabaseContext).Assembly);
        //    base.OnModelCreating(modelBuilder);
        //}

        ////public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        ////{
        ////    foreach (var entry in base.ChangeTracker.Entries<AggregateRoot>()
        ////        .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        ////    {
        ////        entry.Entity.DateModified = DateTime.Now;
        ////        //entry.Entity.ModifiedBy = _userService.UserId;
        ////        if (entry.State == EntityState.Added)
        ////        {
        ////            entry.Entity.DateCreated = DateTime.Now;
        ////            //entry.Entity.CreatedBy = _userService.UserId;
        ////        }
        ////    }

        ////    return base.SaveChangesAsync(cancellationToken);
        ////}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{

        //    foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
        //            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        //    {
        //        entry.Entity.DateModified = DateTime.Now;

        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.DateCreated = DateTime.Now;
        //        }

        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableStatuses();
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void UpdateAuditableStatuses()
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
             .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.IsDeleted = false;
                }

            }
        }
        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Deleted))
            {
                entry.State = EntityState.Modified;
                entry.Entity.DeletedAt = DateTime.Now;
                entry.Entity.IsDeleted = true;
            }
        }
    }
}
