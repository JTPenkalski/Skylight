using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Skylight.API.Configuration;

/// <summary>
/// In-depth configuration setup for the <c>AddSwaggerGen()</c> call during bootstrapping.
/// Configures settings how the swagger.json file generates, according to the OpenAPI specification.
/// </summary>
public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
	: IConfigureOptions<SwaggerGenOptions>
{
	public void Configure(SwaggerGenOptions options)
	{
		foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
		{
			options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
		}
	}

	protected static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
	{
		OpenApiInfo info = new()
		{
			Title = $"{nameof(Skylight)} API",
			Description = "API for Skylight, a web application for viewing, tracking, and cataloging weather events.",
			Version = description.ApiVersion.ToString()
		};

		if (description.IsDeprecated)
		{
			info.Description += " (deprecated)";
		}

		return info;
	}
}
