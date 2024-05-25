namespace Skylight.Domain.Entities;

/// <summary>
/// A notification used to inform people about impending weather, with varying degrees of severity.
/// </summary>
public class WeatherAlert : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Source { get; set; }

    public required float Severity { get; set; }
}
