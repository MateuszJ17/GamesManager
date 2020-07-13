using AutoMapper;
using GameManagerEntities;
using GamesManager.Controllers;
using GamesManagerRepository.Implementations;
using GamesManagerRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GamesManager.Extensions
{
    public static class ConfigureServicesExtensions
    {
        /// <summary>
        /// Extension method to add simple CORS policy
        /// </summary>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }

        /// <summary>
        /// Extension method to register PostgreSQL DbContext
        /// </summary>
        /// <param name="configuration">App IConfiguration</param>
        public static void ConfigurePostgresDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GamesManagerDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"));
            });
        }

        /// <summary>
        /// Extension method to add AutoMapper
        /// </summary>
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }

        /// <summary>
        /// Extension method to register services
        /// </summary>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IGameViewHistoriesRepository, GameViewHistoriesRepository>();
        }

        /// <summary>
        /// Extension method to configure built-in logger service
        /// </summary>
        public static void ConfigureLogger(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<GamesController>>();
            services.AddSingleton(typeof(ILogger), logger);
        }
    }
}