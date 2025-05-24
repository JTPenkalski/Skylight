using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Users;

/// <summary>
/// A User Claim within the application.
/// </summary>
public class UserClaim : IdentityUserClaim<Guid>;
