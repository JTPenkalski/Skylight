namespace Skylight.Domain.Entities;

/// <summary>
/// A unique geographic position where weather occurs.
/// </summary>
public class Location : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? State { get; set; }

	public string? ExternalId { get; set; }
}
