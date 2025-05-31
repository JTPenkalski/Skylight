using Skylight.Application.Common.Identity;

namespace Skylight.Infrastructure.Identity.Users;

public class SkylightSystemUserService : ICurrentUserService
{
	public Guid GetCurrentUserId() =>
		SkylightUsers.SystemId;
}
