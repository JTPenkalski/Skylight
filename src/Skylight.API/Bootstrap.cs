using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Skylight.API.Controllers;
using System.Text.Json.Serialization;

namespace Skylight.API;

public static class Bootstrap
{
	/// <summary>
	/// Adds required services for the <see cref="API"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IServiceCollection"/>.</returns>
	public static IServiceCollection AddApi(this IServiceCollection services)
	{
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
	/// Adds development-only routing for the <see cref="API"/> layer.
	/// </summary>
	/// <returns>The modified <see cref="IEndpointRouteBuilder"/>.</returns>
	public static IEndpointRouteBuilder MapDevelopmentApi(this IEndpointRouteBuilder application)
	{
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
