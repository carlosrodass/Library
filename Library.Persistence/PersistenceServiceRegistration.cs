﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Persistence.DataBaseContext;
using MyLibrary.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence
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
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddScoped<IKeyPointRepository, KeyPointRepository>();
            services.AddScoped<IHubRepository, HubRepository>();

            return services;
        }

    }
}
