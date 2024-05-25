using Skylight.Domain.Constants;

namespace Skylight.Domain.Entities;

/// <summary>
/// Represents a modification to the base <see cref="WeatherAlert.Severity"/> value.
/// </summary>
/// <remarks>
/// This allows identification of rarer <see cref="WeatherAlert"/> instances, which usually correspond to more severe <see cref="WeatherIncident"/> instances.
/// </remarks>
public class WeatherAlertModifier : BaseAuditableEntity
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required float Bonus { get; set; }
    
    public required WeatherAlertModifierOperation Operation { get; set; }
}
