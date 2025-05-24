using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Application.Behaviors;
using System.Reflection;

namespace Skylight.Application;

public static class Bootstrap
{
	/// <summary>
	/// Adds required services for the <see cref="Application"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IServiceCollection"/>.</returns>
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		Assembly assembly = typeof(Bootstrap).Assembly;

		// Add Application Services
		services
			.AddValidatorsFromAssembly(assembly, lifetime: ServiceLifetime.Singleton)
			.AddMediator(options =>
			{
				options.ServiceLifetime = ServiceLifetime.Transient;
			})
			.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>))
			.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
			.Scan(scan => scan
				.FromAssemblies(assembly)
					.AddClasses()
					.AsMatchingInterface()
					.WithScopedLifetime());

		return services;
	}
}
