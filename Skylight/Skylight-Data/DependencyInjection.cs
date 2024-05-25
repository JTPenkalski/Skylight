﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Skylight.Application.Configuration;
using Skylight.Application.Interfaces.Data;
using Skylight.Data.Contexts;
using Skylight.Data.Initializers;
using Skylight.Domain.Exceptions;
using System.Reflection;

namespace Skylight.Data;

/// <summary>
/// Utility to configure the dependency injection for the <see cref="Data"/> layer.
/// </summary>
public static class DependencyInjection
{
    private const string ConnectionName = "Default";

    /// <summary>
    /// Adds required services for the <see cref="Data"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration, bool isProduction)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;
        string? connectionString = configuration.GetConnectionString(ConnectionName);

        InvalidConnectionStringException.ThrowIfNullOrWhiteSpace(connectionString, ConnectionName);

        services
            .AddScoped<ISkylightContextInitializer, DefaultSkylightContextInitializer>()
            .Scan(scan => scan
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime()
            .FromAssemblies(assembly)
                .AddClasses()
                .AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IInterceptor)))
                .WithScopedLifetime());

        // Add EF Core Database
        services.AddDbContext<SkylightContext>((provider, options) =>
        {
            options
                .UseLazyLoadingProxies()
                .AddInterceptors(provider.GetServices<IInterceptor>())
                .UseSqlServer(connectionString);

            options.EnableSensitiveDataLogging(!isProduction);
        });
        
        return services;
    }

    /// <summary>
    /// Adds development-only middleware for the <see cref="Data"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IApplicationBuilder UseDevelopmentData(this IApplicationBuilder app)
    {
        // Use EF Core Context Initializer
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        DatabaseOptions options = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

        if (options.UseCreateAndDropMigrations)
        {
            scope.ServiceProvider
               .GetRequiredService<ISkylightContextInitializer>()
               .InitializeAsync()
               .GetAwaiter()
               .GetResult();
        }

        return app;
    }
}
