using Skylight.Domain.Constants;

namespace Skylight.Domain.Entities;

/// <summary>
/// Signifies participation of some degree from a <see cref="StormTracker"/> in a <see cref="WeatherEvent"/>.
/// </summary>
public class WeatherEventParticipant : BaseAuditableEntity
{
    public required virtual WeatherEvent Event { get; set; }

    public required virtual StormTracker Tracker { get; set; }

    public required virtual ParticipationMethod ParticipationMethod { get; set; }
}
