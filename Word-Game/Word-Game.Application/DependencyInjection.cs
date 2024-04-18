using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Application.Abstractions;
using Word_Game.Application.Abstractions.IServices;
using Word_Game.Application.Abstractions.Services.LevelServices;
using Word_Game.Application.Abstractions.Services.UserServices;
using Word_Game.Application.Abstractions.Services.WordServices;

namespace Word_Game.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILevel, LevelService>();
            services.AddScoped<IWordService, WordService>();

            return services;
        }
    }
}
