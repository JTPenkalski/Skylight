using Microsoft.Extensions.DependencyInjection;
using Skylight.DatabaseContexts.Factories;
using Skylight.Services;

namespace Skylight.Startup.Services
{
    public static class DbContextRepositoryServices
    {
        public static IServiceCollection AddDbContextRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherExperienceContextFactory, WeatherExperienceContextFactory>();

            return services;
        }
    }
}