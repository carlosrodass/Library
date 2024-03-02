using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Identity.DbContext
{
    public class LibraryIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryIdentityDbContext(DbContextOptions<LibraryIdentityDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(LibraryIdentityDbContext).Assembly);
        }

    }
}
