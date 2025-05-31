using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Users;

/// <summary>
/// A User Token within the application.
/// </summary>
public class UserToken : IdentityUserToken<Guid>;
