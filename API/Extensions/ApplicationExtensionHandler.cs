using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.HobbyLists;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationExtensionHandler
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration
        configuration)
        {
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            service.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            service.AddMediatR(serv => serv.RegisterServicesFromAssembly(typeof(HobbyLists.Handler).Assembly));

            service.AddCors(cors =>
            {
                cors.AddPolicy("addcors", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            service.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return service;
        }
    }
}