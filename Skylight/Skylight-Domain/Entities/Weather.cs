namespace Skylight.Domain.Entities;

/// <summary>
/// A specific type of weather.
/// </summary>
public class Weather : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public virtual ICollection<WeatherEvent> Events { get; set; } = new List<WeatherEvent>();
}
