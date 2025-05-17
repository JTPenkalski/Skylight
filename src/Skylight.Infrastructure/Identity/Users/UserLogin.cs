using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Users;

/// <summary>
/// A User Login within the application.
/// </summary>
public class UserLogin : IdentityUserLogin<Guid>;
