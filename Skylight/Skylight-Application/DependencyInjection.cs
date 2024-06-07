using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Domain.Extensions;
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
			.AddValidatorsFromAssembly(assembly)
            .AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);

                IEnumerable<Type> pipelineBehaviorTypes = assembly.GetTypes()
                    .Where(t => t.IsAssignableToGeneric(typeof(IPipelineBehavior<,>)));

                foreach (Type type in pipelineBehaviorTypes)
                {
                    config.AddOpenBehavior(type);
                }
            })
            .Scan(scan => scan
                .FromAssemblies(assembly)
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime());

            return services;
    }
}
