using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Skylight.Application;

/// <summary>
/// Utility to configure the dependency injection for the <see cref="Application"/> layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds required services for the <see cref="Application"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        // Add Application Services
        services
            .AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

        return services;
    }
}
