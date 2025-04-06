using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Skylight.AppDefaults;

namespace Skylight.ServiceDefaults;

/// <summary>
/// Adds common .NET Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
/// This project should be referenced by each service project in your solution.
/// </summary>
/// <remarks>
/// https://aka.ms/dotnet/aspire/service-defaults
/// </remarks>
public static class Extensions
{
    public static TBuilder AddServiceDefaults<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
    {
		builder
			.AddAppDefaults()
			.AddDefaultHealthChecks()
			.ConfigureServiceOpenTelemetry();

		return builder;
	}

	public static IHostApplicationBuilder ConfigureServiceOpenTelemetry(this IHostApplicationBuilder builder)
	{
		builder.Services
			.ConfigureOpenTelemetryMeterProvider(metrics => metrics.AddAspNetCoreInstrumentation())
			.ConfigureOpenTelemetryTracerProvider(tracing => tracing.AddAspNetCoreInstrumentation());

		return builder;
	}

    public static TBuilder AddDefaultHealthChecks<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
    {
        builder.Services
			.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }

    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            // All health checks must pass for app to be considered ready to accept traffic after starting
            app.MapHealthChecks("/health");

            // Only health checks tagged with the "live" tag must pass for app to be considered alive
            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
        }

        return app;
    }
}
