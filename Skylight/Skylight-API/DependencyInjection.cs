﻿using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Skylight.API.Configuration;
using Skylight.Controllers;
using Skylight.Infrastructure.Jobs;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Skylight.Web;

/// <summary>
/// Utility to configure the dependency injection for the <see cref="Web"/> layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds required services for the <see cref="Web"/> layer.
    /// </summary>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddWeb(this IServiceCollection services, bool isProduction)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        // Add MVC Services
        services
            .AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        // Add API Versioning Services
        services
            .AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(SkylightApiVersion.MAJOR, SkylightApiVersion.MINOR);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                // Specify group name for versions as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        // Add Web Services
        services
            .AddSwaggerGen()
			.Scan(scan => scan
				.FromAssemblies(assembly)
					.AddClasses()
					.AsImplementedInterfaces(t => t.IsAssignableTo(typeof(IJobScheduler)))
					.WithSingletonLifetime());

        // Configure Services
        services
            .ConfigureOptions<ConfigureSwaggerOptions>();
        
		// Add Development Services
		if (!isProduction)
		{
			// Add CORS
			services.AddCors(options => options.AddPolicy(
				SkylightOrigins.LocalHostPolicy,
				builder => builder
					.WithOrigins("https://localhost:4200")
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials()));
		}

        return services;
    }

	/// <summary>
	/// Adds background jobs for the <see cref="Web"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="WebApplication"/>.</returns>
	public static WebApplication UseBackgroundJobs(this WebApplication app)
	{
		// Add Jobs
		IEnumerable<IJobScheduler> jobSchedulers = app.Services.GetServices<IJobScheduler>();
		foreach (IJobScheduler jobScheduler in jobSchedulers)
		{
			jobScheduler.Schedule(app, app.Configuration);
		}

		return app;
	}

	/// <summary>
	/// Adds development-only middleware for the <see cref="Web"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="WebApplication"/>.</returns>
	public static WebApplication UseDevelopmentWeb(this WebApplication app)
    {
        // Use Swagger UI
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            // Serve the Swagger UI by default at root URL
            options.RoutePrefix = string.Empty;

            // Create JSON endpoints for all API versions
            foreach (ApiVersionDescription description in app.DescribeApiVersions())
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
            }
        });

        return app;
    }
}
