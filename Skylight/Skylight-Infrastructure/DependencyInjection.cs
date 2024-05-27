using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Infrastructure.Configuration;
using System.Reflection;

namespace Skylight.Infrastructure;

/// <summary>
/// Utility to configure the dependency injection for the <see cref="Infrastructure"/> layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds required services for the <see cref="Infrastructure"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        // Add Configuration
        services
            .Configure<NationalWeatherServiceClientOptions>(configuration.GetSection(NationalWeatherServiceClientOptions.RootKey));

        // Add Time Provider
        services.AddSingleton(TimeProvider.System);

        // Add Infrastructure Services
        services
			.AddValidatorsFromAssembly(assembly)
			.Scan(scan => scan
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime());

        return services;
    }
}
