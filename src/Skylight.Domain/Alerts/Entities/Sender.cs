using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class Sender : BaseAuditableEntity
{
	public required string Code { get; set; }

	public required string Name { get; set; }
}
