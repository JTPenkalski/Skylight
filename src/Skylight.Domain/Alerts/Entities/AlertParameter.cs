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

public static class AlertParameterValues
{
	public const string Catastrophic = "CATASTROPHIC";
	public const string Destructive = "DESTRUCTIVE";
	public const string Considerable = "CONSIDERABLE";
	public const string Observed = "OBSERVED";
	public const string RadarIndicated = "RADAR INDICATED";
	public const string RadarAndGaugeIndicated = "RADAR AND GAUGE INDICATED";
	public const string Possible = "POSSIBLE";
	public const string Significant = "SIGNIFICANT";
}
