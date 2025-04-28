using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertType : BaseAuditableEntity
{
	public required string Code { get; set; }

	public required string Name { get; set; }

	public required string Description { get; set; }

	public required AlertLevel Level { get; set; }
}
