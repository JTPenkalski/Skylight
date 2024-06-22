using FluentValidation;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Identity;
using Skylight.Infrastructure.Jobs;
using System.Reflection;
using System.Text.Json.Serialization;

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
            .Configure<NationalWeatherServiceClientOptions>(configuration.GetSection(NationalWeatherServiceClientOptions.RootKey))
            .Configure<PublishDomainEventsJobOptions>(configuration.GetSection(PublishDomainEventsJobOptions.RootKey))
            .Configure<SkylightIdentityOptions>(configuration.GetSection(SkylightIdentityOptions.RootKey));

        // Add Time Provider
        services.AddSingleton(TimeProvider.System);

        // Add Hangfire
        services.AddHangfire(config =>
            config.UseSqlServerStorage(configuration.GetConnectionString("Default")))
            .AddHangfireServer();

		// Add SignalR
		services.AddSignalR()
			.AddJsonProtocol(options =>
			{
				options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});

        // Add Infrastructure Services
        services
			.AddValidatorsFromAssembly(assembly)
			.Scan(scan => scan
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime()
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IJob)))
                    .WithScopedLifetime());

        return services;
    }

    /// <summary>
    /// Adds development-only middleware for the <see cref="Infrastructure"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseDevelopmentInfrastructure(this IApplicationBuilder app)
    {
        // Use Hangfire UI
        app.UseHangfireDashboard("/jobs", options: new DashboardOptions
        {
            Authorization = []
        });

        return app;
    }
}
