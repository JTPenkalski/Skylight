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

	/// <summary>
	/// Soft-deletes this entity from the data store.
	/// </summary>
	/// <returns>True if the entity was successfully deleted, false otherwise.</returns>
	public bool Delete()
	{
		if (IsDeleted) return false;

		DeletedOn = DateTimeOffset.UtcNow;

		return true;
	}
}
