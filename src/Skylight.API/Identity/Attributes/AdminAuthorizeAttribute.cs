using Microsoft.AspNetCore.Authorization;
using Skylight.Application.Identity;

namespace Skylight.API.Identity.Attributes;

/// <summary>
/// Automatically requires the <see cref="Admin"/> role.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class AdminAuthorizeAttribute : AuthorizeAttribute
{
	public AdminAuthorizeAttribute() : base() =>
		Roles = SkylightRoles.Admin;
}
