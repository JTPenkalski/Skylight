using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertZone : BaseAuditableEntity
{
	public required string State { get; set; }

	public required int Number { get; set; }

	public required ZoneType Type { get; set; }
}
