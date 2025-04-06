using Microsoft.Extensions.DependencyInjection;
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
			.AddMediator()
			.Scan(scan => scan
				.FromAssemblies(assembly)
					.AddClasses()
					.AsMatchingInterface()
					.WithScopedLifetime());

		return services;
	}
}
