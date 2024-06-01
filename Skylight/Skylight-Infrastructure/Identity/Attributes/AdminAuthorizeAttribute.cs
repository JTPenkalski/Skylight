using Microsoft.AspNetCore.Authorization;
using static Skylight.Infrastructure.Identity.Roles;

namespace Skylight.Infrastructure.Identity.Attributes;

/// <summary>
/// Automatically requires the <see cref="Admin"/> role.
/// </summary>
public class AdminAuthorizeAttribute : AuthorizeAttribute
{
	public AdminAuthorizeAttribute() : base() => Roles = Admin;
}
