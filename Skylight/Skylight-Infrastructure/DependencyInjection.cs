using Microsoft.Extensions.DependencyInjection;
using System;
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
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        // Add Time Provider
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
