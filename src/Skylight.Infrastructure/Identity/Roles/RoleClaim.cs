using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Roles;

/// <summary>
/// A Role Claim within the application.
/// </summary>
public class RoleClaim : IdentityRoleClaim<Guid>;
