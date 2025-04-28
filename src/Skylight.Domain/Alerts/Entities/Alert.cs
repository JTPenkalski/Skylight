using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class Alert : BaseAuditableEntity
{
	private readonly HashSet<AlertZone> _zones = [];

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

	public string? ExternalId { get; set; }

	public IReadOnlySet<AlertZone> Zones => _zones;

	public bool AddZone(AlertZone zone) =>
		_zones.Add(zone);

	public bool RemoveZone(AlertZone zone) =>
		_zones.Remove(zone);
}
