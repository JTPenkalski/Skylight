using Microsoft.AspNetCore.Authorization;
using static Skylight.Application.UseCases.Users.Constants.Roles;

namespace Skylight.Infrastructure.Identity.Attributes;

/// <summary>
/// Automatically requires the <see cref="Admin"/> role.
/// </summary>
public class AdminAuthorizeAttribute : AuthorizeAttribute
{
	public AdminAuthorizeAttribute() : base() => Roles = Admin;
}
