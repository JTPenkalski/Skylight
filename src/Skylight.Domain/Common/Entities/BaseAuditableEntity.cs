namespace Skylight.Domain.Common.Entities;

/// <summary>
/// Represents the shared auditable properties of all domain entities.
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
	public DateTimeOffset CreatedOn { get; set; }

	public string? CreatedBy { get; set; }

	public DateTimeOffset? ModifiedOn { get; set; }

	public string? ModifiedBy { get; set; }

	public DateTimeOffset? DeletedOn { get; set; }

	public string? DeletedBy { get; set; }

	public bool IsDeleted =>
		DeletedOn.HasValue;
}
