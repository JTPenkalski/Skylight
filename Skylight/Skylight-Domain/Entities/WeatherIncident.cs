namespace Skylight.Domain.Entities;

/// <summary>
/// An inidividual weather occurence that happened during a <see cref="WeatherEvent"/>.
/// </summary>
public class WeatherIncident : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }
}
