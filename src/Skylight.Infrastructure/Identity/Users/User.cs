using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Users;

/// <summary>
/// A User within the application.
/// </summary>
public class User : IdentityUser<Guid>;
