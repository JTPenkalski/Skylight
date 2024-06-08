﻿namespace Skylight.Domain.Entities;

/// <summary>
/// Aggregates all individual <see cref="WeatherIncident"/> occurences into a single, cumulative event.
/// </summary>
public class WeatherEvent : BaseAuditableEntity
{
	private readonly List<WeatherEventAlert> alerts = [];
	private readonly List<WeatherEventParticipant> participants = [];

	public required string Name { get; set; }

    public required string Description { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public long? DamageCost { get; set; }

    public int? AffectedPeople { get; set; }

	public virtual IReadOnlyList<WeatherEventAlert> Alerts => alerts;

    public virtual IReadOnlyList<WeatherEventParticipant> Participants => participants;

    public void AddParticipant(WeatherEventParticipant participant)
    {
        participants.Add(participant);
    }

    public void RemoveParticipant(WeatherEventParticipant participant)
    {
        participants.Remove(participant);
    }

    public void AddAlert(WeatherEventAlert alert)
    {
        if (alert.ExternalId is not null && Alerts.Any(x => x.ExternalId == alert.ExternalId)) return;
		
        alerts.Add(alert);
    }

    public void RemoveAlert(WeatherEventAlert alert)
    {
        alerts.Remove(alert);
    }
}
