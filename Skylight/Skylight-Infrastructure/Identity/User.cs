using Microsoft.AspNetCore.Identity;
using Skylight.Domain.Entities;

namespace Skylight.Infrastructure.Identity;

/// <summary>
/// A user of the <see cref="Skylight"/> application.
/// </summary>
public class User : IdentityUser<Guid>
{
	public required virtual StormTracker StormTracker { get; set; }
}
