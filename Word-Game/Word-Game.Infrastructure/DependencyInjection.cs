using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Application.Abstractions;
using Word_Game.Domain.Entities;
using Word_Game.Infrastructure.Persistance;
using Word_Game.Infrastructure.Repositories;

namespace Word_Game.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options=>{
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(config.GetConnectionString(""));
            });


            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();

            return services;
        }
    }
}
