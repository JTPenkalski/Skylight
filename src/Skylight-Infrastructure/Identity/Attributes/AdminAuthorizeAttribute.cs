using Microsoft.AspNetCore.Authorization;
using static Skylight.Application.UseCases.Users.Constants.Roles;

namespace Skylight.Infrastructure.Identity.Attributes;

/// <summary>
/// Automatically requires the <see cref="Admin"/> role.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AdminAuthorizeAttribute : AuthorizeAttribute
{
	public AdminAuthorizeAttribute() : base() => Roles = Admin;
}
