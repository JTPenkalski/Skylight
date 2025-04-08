using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertZone : BaseAuditableEntity
{
	public required string Code { get; set; }

	public string? State { get; set; }
}
