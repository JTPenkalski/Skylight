using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Roles;

/// <summary>
/// A Role within the application.
/// </summary>
public class Role : IdentityRole<Guid>;
