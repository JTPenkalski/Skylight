using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Skylight.API.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Skylight.API.Filters;

/// <summary>
/// Requires the proper auth on only the API endpoints that require it.
/// </summary>
public class AuthorizationOperationFilter : IOperationFilter
{
	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		bool isAnonymous = context.MethodInfo
			.GetCustomAttributes(true)
			.OfType<AllowAnonymousAttribute>()
			.Any();

		if (!isAnonymous)
		{
			operation.Security =
			[
				new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Name = ConfigureSwaggerOptions.BearerScheme,
							In = ParameterLocation.Header,
							Reference = new OpenApiReference
							{
								Id = ConfigureSwaggerOptions.BearerScheme,
								Type = ReferenceType.SecurityScheme
							}
						},
						[]
					}
				}
			];
		}
	}
}
