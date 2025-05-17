using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Users;

/// <summary>
/// A User Role within the application.
/// </summary>
public class UserRole : IdentityUserRole<Guid>;
