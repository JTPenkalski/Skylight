namespace Skylight.Domain.Entities;

/// <summary>
/// A unique geographic position where weather occurs.
/// </summary>
public class Location : BaseAuditableEntity
{
    public required string City { get; set; }

    public required string Country { get; set; }
}
