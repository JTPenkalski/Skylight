using Microsoft.AspNetCore.Http;
using Skylight.Application.Common.Identity;
using System.Security.Claims;

namespace Skylight.Infrastructure.Identity.Users;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
	public Guid GetCurrentUserId()
	{
		string? user = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
		bool isValidUser = Guid.TryParse(user, out Guid userId);

		return isValidUser
			? userId
			: SkylightUsers.SystemId;
	}
}
