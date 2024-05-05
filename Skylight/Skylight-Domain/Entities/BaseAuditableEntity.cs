namespace Skylight.Domain.Entities;

/// <summary>
/// Represents the shared auditable properties of all domain entities.
/// </summary>
public class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public DateTimeOffset? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
