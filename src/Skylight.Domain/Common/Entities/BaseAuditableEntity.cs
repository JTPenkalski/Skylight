namespace Skylight.Domain.Common.Entities;

/// <summary>
/// Represents the shared auditable properties of all domain entities.
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity, IAuditable
{
	public DateTimeOffset CreatedOn { get; set; }

	public Guid? CreatedBy { get; set; }

	public DateTimeOffset? ModifiedOn { get; set; }

	public Guid? ModifiedBy { get; set; }

	public DateTimeOffset? DeletedOn { get; set; }

	public Guid? DeletedBy { get; set; }
}
