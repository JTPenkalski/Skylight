using Skylight.Domain.Alerts.Events;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skylight.Domain.Alerts.Entities;

public class Alert : BaseAuditableEntity
{
	private readonly HashSet<AlertZone> _zones = [];
	private readonly HashSet<AlertParameter> _parameters = [];

	public required AlertType Type { get; set; }

	public required AlertSender Sender { get; set; }

	public required string Headline { get; set; }

	public required string Description { get; set; }

	public required string Instruction { get; set; }

	public required DateTimeOffset SentOn { get; set; }

	public required DateTimeOffset EffectiveOn { get; set; }

	public required DateTimeOffset BeginsOn { get; set; }

	public required DateTimeOffset ExpiresOn { get; set; }

	public required DateTimeOffset EndsOn { get; set; }

	public required AlertMessageType MessageType { get; set; }

	public required AlertSeverity Severity { get; set; }

	public required AlertCertainty Certainty { get; set; }

	public required AlertUrgency Urgency { get; set; }

	public required AlertResponse Response { get; set; }

	public bool IsEffectuated { get; set; }

	public bool IsExpired { get; set; }

	public string? ExternalId { get; set; }

	public IReadOnlySet<AlertZone> Zones => _zones;

	public IReadOnlySet<AlertParameter> Parameters => _parameters;

	[NotMapped]
	public string ObservationType
	{
		get
		{
			// Associate a priority with each potential observation type, from highest to lowest
			var observationTypes = new[]
			{
				AlertParameterKey.TornadoDamageThreat,
				AlertParameterKey.ThunderstormDamageThreat,
				AlertParameterKey.FlashFloodDamageThreat,
				AlertParameterKey.TornadoDetection,
				AlertParameterKey.FlashFloodDetection,
				AlertParameterKey.ThunderstormThreat,
			}.Select((x, i) => new { Key = x, Priority = i });

			string? observationType = Parameters
				// Ignore certain Pararmeter values
				.Where(x => !x.Value.Equals(AlertParameterValues.Possible, StringComparison.CurrentCultureIgnoreCase))
				// Associate each of this Alert's Parameters with the priority established above
				.Join(
					observationTypes,
					x => x.Key,
					x => x.Key,
					(x, y) => new { Parameter = x, ObservationType = y })
				// Sort the Parameters according to their priority
				.OrderBy(x => x.ObservationType.Priority)
				// Get the text value of each Parameter
				.Select(x => x.Parameter.Value)
				// Get the first one (which should be the highest priority)
				.FirstOrDefault();

			observationType ??= Type.Level.ToString();

			return observationType.ToTitleCase();
		}
	}

	public void Effectuate()
	{
		IsEffectuated = true;
		AddEvent(new AlertEffectuatedEvent(Id));
	}

	public void Expire()
	{
		IsExpired = true;
		AddEvent(new AlertExpiredEvent(Id));
	}

	public bool AddZone(Zone zone)
	{
		var alertZone = new AlertZone
		{
			Alert = this,
			Zone = zone,
		};

		return _zones.Add(alertZone);
	}

	public bool RemoveZone(Zone zone)
	{
		int removed = _zones.RemoveWhere(x => x.Zone == zone);

		return removed > 0;
	}

	public bool AddParameter(AlertParameterKey key, string? value)
	{
		if (string.IsNullOrWhiteSpace(value)) return false;

		var alertParameter = new AlertParameter
		{
			Key = key,
			Value = value,
			Alert = this,
		};

		return _parameters.Add(alertParameter);
	}

	public bool RemoveParameter(AlertParameterKey key)
	{
		int removed = _parameters.RemoveWhere(x => x.Key == key);

		return removed > 0;
	}
}
