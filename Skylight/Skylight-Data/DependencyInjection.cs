using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Contexts;
using System;
using System.Reflection;

namespace Skylight.Data;

/// <summary>
/// Utility to configure the dependency injection for the <see cref="Data"/> layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds required services for the <see cref="Data"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddData(this IServiceCollection services, string? connectionString)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        ArgumentNullException.ThrowIfNull(connectionString);

        // Currently configured to set up Entity Framework Core
        services.AddDbContext<WeatherExperienceContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
