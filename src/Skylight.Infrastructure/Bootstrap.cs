using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Application.Data;
using Skylight.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Data;
using Skylight.Infrastructure.Data.Initializers;
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

		// Add Configuration
		services
			.AddOptions<NationalWeatherServiceOptions>().Bind(configuration.GetSection(NationalWeatherServiceOptions.RootKey)).ValidateOnStart();

		// Add Time Provider
		services.AddSingleton(TimeProvider.System);

		// Add EF Core Database
		services
			.AddDbContext<SkylightDbContext>((provider, options) =>
			{
				options
					.AddInterceptors(provider.GetServices<IInterceptor>())
					.UseNpgsql(configuration.GetConnectionString("skylight-postgres-db"));

				options.EnableSensitiveDataLogging(!isProduction);
			});

		// Add Infrastructure Services
		services
			.AddValidatorsFromAssembly(assembly)
			.AddScoped<ISkylightDbContextInitializer, DefaultSkylightDbContextInitializer>()
			.Scan(scan => scan
				.FromAssemblies(assembly)
					.AddClasses()
					.AsMatchingInterface()
					.WithScopedLifetime());

		return services;
	}

	/// <summary>
	/// Adds development-only middleware for the <see cref="Infrastructure"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IApplicationBuilder"/>.</returns>
	public static IApplicationBuilder UseDevelopmentInfrastructure(this IApplicationBuilder app)
	{
		// Use EF Core Context Initializer
		using IServiceScope scope = app.ApplicationServices.CreateScope();

		scope.ServiceProvider
			.GetRequiredService<ISkylightDbContextInitializer>()
			.InitializeAsync()
			.GetAwaiter()
			.GetResult();

		return app;
	}
}
