using Asp.Versioning;
using Hangfire;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Skylight.API.Configuration;
using Skylight.API.Jobs;
using Skylight.Infrastructure.Jobs.Schedules;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Skylight.API;

public static class Bootstrap
{
	/// <summary>
	/// Adds required services for the <see cref="API"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IServiceCollection"/>.</returns>
	public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration, bool isProduction)
	{
		Assembly assembly = typeof(Bootstrap).Assembly;

		// Add Configuration
		services
			.AddOptions<AddCurrentWeatherAlertsJobSchedulerOptions>().Bind(configuration.GetSection(AddCurrentWeatherAlertsJobSchedulerOptions.RootKey)).ValidateOnStart();

		// Add MVC Services
		services
			.AddControllers()
			.AddJsonOptions(options =>
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

		// Add API Versioning Services
		services
			.AddOpenApiVersion(SkylightApiVersion.Current)
			.AddApiVersioning(options =>
			{
				options.ApiVersionReader = new UrlSegmentApiVersionReader();
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(SkylightApiVersion.Current);
				options.ReportApiVersions = true;
			})
			.AddMvc()
			.AddApiExplorer(options =>
			{
				// Specify group name for versions as "'v'major[.minor][-status]"
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

		// Add CORS
		services.AddCors(options =>
		{
			if (isProduction)
			{
				options.AddDefaultPolicy(builder =>
					builder
						.WithOrigins("" /* TODO */)
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowCredentials());
			}
			else
			{
				options.AddDefaultPolicy(builder =>
					builder
						.SetIsOriginAllowed(origin => new Uri(origin).Host == SkylightOrigins.LocalHost)
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowCredentials());
			}
		});

		// Add API Services
		services
			.AddEndpointsApiExplorer()
			.Scan(scan => scan
				// Job Schedulers
				.FromAssemblies(assembly)
					.AddClasses()
					.AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IJobScheduler)))
					.WithSingletonLifetime());

		return services;
	}

	private static IServiceCollection AddOpenApiVersion(this IServiceCollection services, double version)
	{
		string name = $"v{version}";

		services
			.AddOpenApi(name, options =>
			{
				options.ShouldInclude = description =>
				{
					return description.RelativePath?.Contains(name) ?? false;
				};

				options
					.AddDocumentTransformer((document, context, cancellationToken) =>
					{
						document.Info = new OpenApiInfo
						{
							Title = "Skylight API",
							Description = "API for managing weather data.",
							Version = name,
						};

						return Task.CompletedTask;
					});
			});

		return services;
	}

	/// <summary>
	/// Adds background jobs for the <see cref="API"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="WebApplication"/>.</returns>
	public static WebApplication UseBackgroundJobs(this WebApplication app)
	{
		// Add Hangfire Jobs
		IEnumerable<IJobScheduler> jobSchedulers = app.Services.GetServices<IJobScheduler>();
		foreach (IJobScheduler jobScheduler in jobSchedulers)
		{
			bool scheduled = jobScheduler.Schedule();

			if (scheduled && jobScheduler.TriggerImmediate)
			{
				RecurringJob.TriggerJob(jobScheduler.Key);
			}
		}

		return app;
	}

	/// <summary>
	/// Adds development-only middleware for the <see cref="API"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IApplicationBuilder"/>.</returns>
	public static IApplicationBuilder UseDevelopmentApi(this IApplicationBuilder application)
	{
		// Use Hangfire UI
		application.UseHangfireDashboard("/jobs", options: new DashboardOptions
		{
			Authorization = []
		});

		return application;
	}

	/// <summary>
	/// Adds development-only routing for the <see cref="API"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IEndpointRouteBuilder"/>.</returns>
	public static IEndpointRouteBuilder MapDevelopmentApi(this IEndpointRouteBuilder application)
	{
		// Map OpenAPI Docs
		application.MapOpenApi();
		application.MapScalarApiReference(options =>
		{
			options
				.WithTitle("Skylight API")
				.WithTheme(ScalarTheme.Purple)
				.AddDocuments($"v{SkylightApiVersion.Current}");
		});

		return application;
	}
}
