﻿namespace Skylight.Domain.Entities;

/// <summary>
/// Aggregates all individual <see cref="WeatherIncident"/> occurences into a single, cumulative event.
/// </summary>
public class WeatherEvent : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public virtual IList<WeatherEventAlert> Alerts { get; set; } = new List<WeatherEventAlert>();

    public virtual IList<WeatherEventParticipant> Participants { get; set; } = new List<WeatherEventParticipant>();

    public void AddParticipant(WeatherEventParticipant participant)
    {
        Participants.Add(participant);
    }
}
