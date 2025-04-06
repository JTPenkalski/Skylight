using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Infrastructure.Data;
using System.Reflection;

namespace Skylight.Infrastructure;

public static class Bootstrap
{
	/// <summary>
	/// Adds required services for the <see cref="Infrastructure"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IServiceCollection"/>.</returns>
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isProduction)
	{
		Assembly assembly = typeof(Bootstrap).Assembly;

		// Add Time Provider
		services.AddSingleton(TimeProvider.System);

		// Add Infrastructure Services
		services
			.Scan(scan => scan
				.FromAssemblies(assembly)
					.AddClasses()
					.AsMatchingInterface()
					.WithScopedLifetime());

		// Add EF Core Database
		services
			.AddDbContext<SkylightDbContext>((provider, options) =>
			{
				options
					.AddInterceptors(provider.GetServices<IInterceptor>())
					.UseNpgsql(configuration.GetConnectionString("skylight-postgress-db"));

				options.EnableSensitiveDataLogging(!isProduction);
			});

		return services;
	}
}
