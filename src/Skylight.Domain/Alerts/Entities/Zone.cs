using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class Zone : BaseAuditableEntity
{
	private readonly HashSet<AlertZone> _alerts = [];

	public required string Code { get; set; }

	public required string Name { get; set; }

	public IReadOnlySet<AlertZone> Alerts => _alerts;
}
