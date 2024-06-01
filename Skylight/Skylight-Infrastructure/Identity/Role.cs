using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity;

/// <summary>
/// A role within the <see cref="Skylight"/> application.
/// </summary>
public class Role : IdentityRole<Guid> { }
