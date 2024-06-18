using Microsoft.AspNetCore.Http;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Infrastructure.Constants;

namespace Skylight.Infrastructure.Identity;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
	public string GetCurrentUser()
	{
		string? currentUserName = httpContextAccessor.HttpContext?.User.Identity?.Name;

		return currentUserName ?? SkylightSystem.Name;
	}
}
