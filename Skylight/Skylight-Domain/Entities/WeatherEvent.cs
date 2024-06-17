using Skylight.Domain.Events;
using Skylight.Domain.Extensions;

namespace Skylight.Domain.Entities;

/// <summary>
/// Aggregates all individual <see cref="WeatherIncident"/> occurences into a single, cumulative event.
/// </summary>
public class WeatherEvent : BaseAuditableEntity
{
	private readonly List<WeatherEventAlert> alerts = [];
	private readonly List<WeatherEventParticipant> participants = [];
	private readonly List<WeatherEventTag> tags = [];

	public required string Name { get; set; }

    public required string Description { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public long? DamageCost { get; set; }

    public int? AffectedPeople { get; set; }

	public virtual IEnumerable<WeatherEventAlert> Alerts => alerts;

    public virtual IEnumerable<WeatherEventParticipant> Participants => participants;
	
    public virtual IEnumerable<WeatherEventTag> Tags => tags;

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
		WeatherEventParticipant? participant = Participants.FirstOrDefault(x => x.Tracker.Id == stormTrackerId);

		if (participant is not null)
		{
			return participants.Remove(participant);
		}
		
		return false;
	}

	public bool AddAlert(WeatherEventAlert alert)
    {
        if (alert.ExternalId is not null && Alerts.Any(x => x.ExternalId == alert.ExternalId)) return false;
		
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

	public bool AddTag(WeatherEventTag tag)
	{
		// TODO: Add logic to prevent the same user from spamming their vote...
		WeatherEventTag? existingTag = Tags.SingleOrDefault(x => x.Tag.Name.Equals(tag.Tag.Name, StringComparison.InvariantCultureIgnoreCase));

		AddEvent(new WeatherEventTagAddedEvent(Id, existingTag?.Id ?? tag.Id));

		if (existingTag is not null) return false;

		tags.Add(tag);

		return true;
	}

	public bool RemoveTag(WeatherEventTag tag)
	{
		return tags.Remove(tag);
	}

	public bool RemoveTagById(Guid tagId)
	{
		return tags.RemoveById(tagId);
	}
}
