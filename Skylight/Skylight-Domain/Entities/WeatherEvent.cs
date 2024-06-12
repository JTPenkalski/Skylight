using Skylight.Domain.Extensions;

namespace Skylight.Domain.Entities;

/// <summary>
/// Aggregates all individual <see cref="WeatherIncident"/> occurences into a single, cumulative event.
/// </summary>
public class WeatherEvent : BaseAuditableEntity
{
	private List<WeatherEventAlert> alerts = [];
	private List<WeatherEventParticipant> participants = [];

	public required string Name { get; set; }

    public required string Description { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public long? DamageCost { get; set; }

    public int? AffectedPeople { get; set; }

	public virtual IReadOnlyList<WeatherEventAlert> Alerts
	{
		get => alerts;
		private set => alerts = [.. value];
	}

    public virtual IReadOnlyList<WeatherEventParticipant> Participants
	{
		get => participants;
		private set => participants = [.. value];
	}

	public bool AddParticipant(WeatherEventParticipant participant)
    {
		if (participants.ContainsNonDefault(participant)) return false;

        participants.Add(participant);

		return true;
    }

    public bool RemoveParticipant(WeatherEventParticipant participant)
    {
        return participants.Remove(participant);
    }

	public bool RemoveParticipantId(Guid participantId)
	{
		return participants.RemoveById(participantId);
	}

	public bool RemoveParticipantByStormTrackerId(Guid stormTrackerId)
	{
		WeatherEventParticipant? participant = participants.Find(x => x.Tracker.Id == stormTrackerId);

		if (participant is not null)
		{
			return participants.Remove(participant);
		}
		
		return false;
	}

	public bool AddAlert(WeatherEventAlert alert)
    {
        if (alert.ExternalId is not null && alerts.Any(x => x.ExternalId == alert.ExternalId)) return false;
		
        alerts.Add(alert);

		return true;
    }

    public bool RemoveAlert(WeatherEventAlert alert)
    {
        return alerts.Remove(alert);
    }

	public bool RemoveAlertById(Guid alertId)
	{
		return alerts.RemoveById(alertId);
	}
}
