using Skylight.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.WeatherIncidentParticipant"/>
public record WeatherIncidentParticipant : BaseModel
{
    [Required]
    public required virtual WeatherIncident Incident { get; init; }

    [Required]
    public required virtual StormTracker Tracker { get; init; }

    [Required]
    public required virtual ParticipationMethod ParticipationMethod { get; init; }
}