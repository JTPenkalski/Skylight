using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertParameter : BaseAuditableEntity
{
	public required AlertParameterKey Key { get; set; }

	public required string Value { get; set; }

	public required Alert Alert { get; set; }

	public T As<T>() =>
		(T)Convert.ChangeType(Value, typeof(T));
}
