using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity;

/// <summary>
/// A user of the <see cref="Skylight"/> application.
/// </summary>
public class User : IdentityUser<Guid> { }
