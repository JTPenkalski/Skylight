using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Skylight.Infrastructure.Identity;

namespace Skylight.API.Configuration;

/// <summary>
/// Configuration setup for the <c>AddIdentity()</c> call during bootstrapping.
/// Configures settings how ASP.NET Identity works.
/// </summary>
public class ConfigureIdentityOptions(IOptions<SkylightIdentityOptions> skylightOptions)
	: IConfigureOptions<IdentityOptions>
{
	public void Configure(IdentityOptions options)
	{
		options.Lockout.AllowedForNewUsers = skylightOptions.Value.LockoutAllowedForNewUsers;
		options.Lockout.MaxFailedAccessAttempts = skylightOptions.Value.LockoutMaxFailedAccessAttempts;

		options.Password.RequiredLength = skylightOptions.Value.PasswordRequiredLength;
		options.Password.RequireNonAlphanumeric = skylightOptions.Value.RequireNonAlphanumeric;
		options.Password.RequireUppercase = skylightOptions.Value.RequireUppercase;
		options.Password.RequireDigit = skylightOptions.Value.RequireDigit;

		options.User.RequireUniqueEmail = skylightOptions.Value.UserRequireUniqueEmail;
	}
}
