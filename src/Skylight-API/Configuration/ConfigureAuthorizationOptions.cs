using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Skylight.Infrastructure.Identity;

namespace Skylight.API.Configuration;

/// <summary>
/// Configuration setup for the <c>AddAuthorization()</c> call during bootstrapping.
/// Configures settings how the Authorization Middleware works.
/// </summary>
public class ConfigureAuthorizationOptions(IOptions<SkylightIdentityOptions> skylightOptions)
	: IConfigureOptions<AuthorizationOptions>
{
	public void Configure(AuthorizationOptions options)
	{
		options.InvokeHandlersAfterFailure = skylightOptions.Value.InvokeHandlersAfterFailure;
	}
}
