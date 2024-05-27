using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Application.Attributes;
using Skylight.Application.Configuration;
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
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        // Add Configuration
        services
            .Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.RootKey));

        // Add Application Services
        services
			.AddValidatorsFromAssembly(assembly)
            .AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);

                IEnumerable<Type> pipelineBehaviorTypes = assembly.GetTypes()
                    .Where(t => t.GetCustomAttribute<ServiceBehaviorAttribute>() is not null);

                foreach (Type type in pipelineBehaviorTypes)
                {
                    config.AddOpenBehavior(type);
                }
            })
            .Scan(scan => scan
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime()
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IRequestExceptionHandler<,,>)))
                    .WithScopedLifetime());

            return services;
    }
}
