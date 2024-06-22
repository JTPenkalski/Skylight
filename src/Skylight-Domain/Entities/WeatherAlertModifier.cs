using Skylight.Domain.Constants;

namespace Skylight.Domain.Entities;

/// <summary>
/// Represents a modification or extension to a <see cref="WeatherAlert"/>.
/// </summary>
/// <remarks>
/// This allows identification of rarer <see cref="WeatherAlert"/> instances, which usually correspond to more severe <see cref="WeatherEvent"/>s.
/// </remarks>
public class WeatherAlertModifier : BaseAuditableEntity
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required float Bonus { get; set; }
    
    public required WeatherAlertModifierOperation Operation { get; set; }
}
