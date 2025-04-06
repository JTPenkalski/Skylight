using Microsoft.AspNetCore.Http;
using Skylight.Application.Identity;
using Skylight.Infrastructure.Identity.Constants;

namespace Skylight.Infrastructure.Identity.Services;

public class CurrentUserService(/*IHttpContextAccessor httpContextAccessor*/) : ICurrentUserService
{
	public string GetCurrentUser()
	{
		string? currentUserName = SkylightIdentities.System; // httpContextAccessor.HttpContext?.User.Identity?.Name;

		return currentUserName ?? SkylightIdentities.System;
	}
}
