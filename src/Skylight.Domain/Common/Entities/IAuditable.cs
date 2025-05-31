namespace Skylight.Domain.Common.Entities;

/// <summary>
/// Defines an entity that has additional data for traceability purposes.
/// </summary>
public interface IAuditable
{
	DateTimeOffset CreatedOn { get; set; }

	Guid? CreatedBy { get; set; }

	DateTimeOffset? ModifiedOn { get; set; }

	Guid? ModifiedBy { get; set; }

	DateTimeOffset? DeletedOn { get; set; }

	Guid? DeletedBy { get; set; }

	/// <summary>
	/// Soft-deletes this entity from the data store.
	/// </summary>
	/// <returns>True if the entity was successfully deleted, false otherwise.</returns>
	bool Delete()
	{
		if (DeletedOn.HasValue) return false;

		DeletedOn = DateTimeOffset.UtcNow;

		return true;
	}
}
