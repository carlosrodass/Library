using Library.Application.Contracts.Persistence;
using Library.Persistence.DataBaseContext;
using Library.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LibraryDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILibraryBookRepository, LibraryBookRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IKeyPointRepository, KeyPointRepository>();
            services.AddScoped<ILibraryBookRepository, LibraryBookRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();

            return services;
        }

    }
}
