using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Skylight.API.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Skylight.API.Configuration;

/// <summary>
/// In-depth configuration setup for the <c>AddSwaggerGen()</c> call during bootstrapping.
/// Configures settings how the swagger.json file generates, according to the OpenAPI specification.
/// </summary>
public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
	: IConfigureOptions<SwaggerGenOptions>
{
	public static string BearerScheme => BearerTokenDefaults.AuthenticationScheme.Replace("Token", string.Empty);

	public void Configure(SwaggerGenOptions options)
	{
		// Swagger Docs
		foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
		{
			options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
		}

		// Auth
		options.AddSecurityDefinition(BearerScheme, new()
		{
			Name = HeaderNames.Authorization,
			Description = "Access Token",
			Type = SecuritySchemeType.Http,
			In = ParameterLocation.Header,
			Scheme = BearerScheme,
			BearerFormat = "ASP.NET Core Identity Proprietary",
		});

		options.OperationFilter<AuthorizationOperationFilter>();
	}

	protected static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
	{
		OpenApiInfo info = new()
		{
			Title = $"{nameof(Skylight)} API",
			Description = "API for Skylight, a web application for monitoring, tracking, and viewing weather events.",
			Version = description.ApiVersion.ToString()
		};

		if (description.IsDeprecated)
		{
			info.Description += " (deprecated)";
		}

		return info;
	}
}
