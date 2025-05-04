using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertZone : BaseAuditableEntity
{
	public required Alert Alert { get; set; }

	public required Zone Zone { get; set; }
}
