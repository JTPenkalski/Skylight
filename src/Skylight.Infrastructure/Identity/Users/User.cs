using Microsoft.AspNetCore.Identity;
using Skylight.Domain.Common.Entities;

namespace Skylight.Infrastructure.Identity.Users;

/// <summary>
/// A User within the application.
/// </summary>
public class User : IdentityUser<Guid>, IAuditable
{
	public DateTimeOffset CreatedOn { get; set; }

	public Guid? CreatedBy { get; set; }

	public DateTimeOffset? ModifiedOn { get; set; }

	public Guid? ModifiedBy { get; set; }

	public DateTimeOffset? DeletedOn { get; set; }

	public Guid? DeletedBy { get; set; }
}
