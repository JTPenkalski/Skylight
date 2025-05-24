using Microsoft.AspNetCore.Http;
using Skylight.Application.Identity;

namespace Skylight.Infrastructure.Identity.Users;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
	public string GetCurrentUser()
	{
		string? currentUserName = httpContextAccessor.HttpContext?.User.Identity?.Name;

		return currentUserName ?? SkylightUsers.System;
	}
}
