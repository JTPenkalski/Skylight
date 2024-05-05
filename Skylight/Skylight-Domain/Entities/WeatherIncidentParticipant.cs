using Skylight.Domain.Constants;

namespace Skylight.Domain.Entities;

/// <summary>
/// Signifies participation of some degree from a <see cref="StormTracker"/> in a <see cref="WeatherIncident"/>.
/// </summary>
public class WeatherIncidentParticipant : BaseAuditableEntity
{
    public required virtual WeatherIncident Incident { get; set; }

    public required virtual StormTracker Tracker { get; set; }

    public required virtual ParticipationMethod ParticipationMethod { get; set; }
}
