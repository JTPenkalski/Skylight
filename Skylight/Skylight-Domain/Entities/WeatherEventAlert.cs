namespace Skylight.Domain.Entities;

/// <summary>
/// Links a type of <see cref="WeatherAlert"/> to a specific <see cref="WeatherEvent"/>.
/// </summary>
public class WeatherEventAlert : BaseAuditableEntity
{
    public required DateTimeOffset Sent { get; set; }
    
    public required DateTimeOffset Effective { get; set; }
    
    public required DateTimeOffset Onset { get; set; }
    
    public required DateTimeOffset Expires { get; set; }
    
    public required DateTimeOffset Ends { get; set; }

    public required virtual WeatherAlert Alert { get; set; }

    public virtual WeatherEvent? Event { get; set; }

    public virtual IList<WeatherAlertModifier> Modifiers { get; set; } = new List<WeatherAlertModifier>();
}
