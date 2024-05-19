namespace Skylight.Domain.Entities;

/// <summary>
/// Represents the shared auditable properties of all domain entities.
/// </summary>
public class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }

    public string CreatedBy { get; set; } = "System";

    public DateTimeOffset? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool Deleted { get; set; }
}
