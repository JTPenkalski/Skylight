using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Skylight.AppDefaults;

/// <summary>
/// Adds common .NET Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
/// This project should be referenced by each service project in your solution.
/// </summary>
/// <remarks>
/// https://aka.ms/dotnet/aspire/service-defaults
/// </remarks>
public static class Extensions
{
	public static IHostApplicationBuilder AddAppDefaults(this IHostApplicationBuilder builder)
	{
		builder.ConfigureAppOpenTelemetry();

		builder.Services
			.AddServiceDiscovery()
			.ConfigureHttpClientDefaults(http =>
			{
				// Turn on resilience
				http.AddStandardResilienceHandler();

				// Turn on service discovery
				http.AddServiceDiscovery();
			});

		return builder;
	}

	public static IHostApplicationBuilder ConfigureAppOpenTelemetry(this IHostApplicationBuilder builder)
	{
		builder.Logging
			.AddOpenTelemetry(logging =>
			{
				logging.IncludeFormattedMessage = true;
				logging.IncludeScopes = true;
			});

		builder.Services
			.AddOpenTelemetry()
				.WithMetrics(metrics =>
				{
					metrics
						.AddHttpClientInstrumentation()
						.AddRuntimeInstrumentation();
				})
				.WithTracing(tracing =>
				{
					tracing
						.AddHttpClientInstrumentation();
				});

		builder
			.AddOpenTelemetryExporters();

		return builder;
	}

	private static IHostApplicationBuilder AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
	{
		bool useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

		if (useOtlpExporter)
		{
			builder.Services
				.AddOpenTelemetry()
				.UseOtlpExporter();
		}

		return builder;
	}
}
