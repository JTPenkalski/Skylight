using FluentValidation;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Skylight.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Data;
using Skylight.Infrastructure.Identity;
using Skylight.Infrastructure.Jobs;
using Skylight.Infrastructure.Jobs.Filters;
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
		services
			.AddOptions<SkylightIdentityOptions>().Bind(configuration.GetSection(SkylightIdentityOptions.RootKey)).ValidateOnStart();
		services
			.AddOptions<JobStorageOptions>().Bind(configuration.GetSection(JobStorageOptions.RootKey)).ValidateOnStart();

		// Add Infrastructure Services
		services
			.AddSingleton(TimeProvider.System)
			.AddValidatorsFromAssembly(assembly)
			.Scan(scan => scan
				.FromAssemblies(assembly)
					.AddClasses()
					.AsMatchingInterface()
					.WithScopedLifetime()
				// EF Core Interceptors
				.FromAssemblies(assembly)
					.AddClasses()
					.AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IInterceptor)))
					.WithScopedLifetime()
				// Jobs
				.FromAssemblies(assembly)
					.AddClasses()
					.AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IJob)))
					.WithScopedLifetime()
				// Job Filters
				.FromAssemblies(assembly)
					.AddClasses()
					.AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IJobFilter)))
					.WithSingletonLifetime());

		// Add EF Core Database
		services
			.AddDbContext<SkylightDbContext>((provider, options) =>
			{
				options
					.AddInterceptors(provider.GetServices<IInterceptor>())
					.UseNpgsql(
						configuration.GetConnectionString("skylight-postgres-db"));

				options.EnableSensitiveDataLogging(!isProduction);
			});

		// Add Hangfire
		services
			.AddHangfire((provider, options) =>
			{
				var filters = provider.GetServices<IJobFilter>();
				foreach (IJobFilter filter in filters)
				{
					options.UseFilter(filter);
				}

				JobStorageOptions storageOptions = provider.GetRequiredService<IOptions<JobStorageOptions>>().Value;
				options
					.UsePostgreSqlStorage(sqlOptions =>
					{
						sqlOptions
							.UseNpgsqlConnection(configuration.GetConnectionString("skylight-postgres-db"));
					},
					new PostgreSqlStorageOptions
					{
						QueuePollInterval = TimeSpan.FromSeconds(storageOptions.QueuePollInterval),
						InvisibilityTimeout = TimeSpan.FromMinutes(storageOptions.InvisibilityTimeout),
					});
			});

		return services;
	}

	/// <summary>
	/// Adds development-only middleware for the <see cref="Infrastructure"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IApplicationBuilder"/>.</returns>
	public static IApplicationBuilder UseDevelopmentInfrastructure(this IApplicationBuilder app)
	{
		return app;
	}
}
