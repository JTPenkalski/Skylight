namespace Skylight.Domain.Entities;

/// <summary>
/// Links a type of <see cref="WeatherAlert"/> to a specific <see cref="WeatherEvent"/>.
/// </summary>
public class WeatherEventAlert : BaseAuditableEntity
{
    public required DateTimeOffset IssuanceTime { get; set; }

    public required virtual WeatherEvent Event { get; set; }

    public required virtual WeatherAlert Alert { get; set; }

    public virtual IList<WeatherAlertModifier> Modifiers { get; set; } = new List<WeatherAlertModifier>();
}
