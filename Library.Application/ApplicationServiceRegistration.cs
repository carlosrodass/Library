using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Application.Services.Abstract;
using MyLibrary.Application.Services.Abstract.BookService;
using MyLibrary.Application.Services.Abstract.HubService;
using MyLibrary.Application.Services.Concrete.BookService;
using MyLibrary.Application.Services.Concrete.HubService;
using MyLibrary.Application.Services.Concrete.ResumeService;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IHubService, HubService>();
            services.AddScoped<IResumeService, ResumeService>();

            return services;
        }

    }
}
