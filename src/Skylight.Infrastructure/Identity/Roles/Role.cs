using Microsoft.AspNetCore.Identity;
using Skylight.Domain.Common.Entities;

namespace Skylight.Infrastructure.Identity.Roles;

/// <summary>
/// A Role within the application.
/// </summary>
public class Role : IdentityRole<Guid>, IAuditable
{
	public DateTimeOffset CreatedOn { get; set; }

	public Guid? CreatedBy { get; set; }

	public DateTimeOffset? ModifiedOn { get; set; }

	public Guid? ModifiedBy { get; set; }

	public DateTimeOffset? DeletedOn { get; set; }

	public Guid? DeletedBy { get; set; }
}
