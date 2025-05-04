using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertParameter : BaseAuditableEntity
{
	public required string Key { get; set; }

	public required string Value { get; set; }

	public required Alert Alert { get; set; }

	public T As<T>() =>
		(T)Convert.ChangeType(Value, typeof(T));
}

public static class AlertParameterKeys
{
	public const string TypeModifier = nameof(TypeModifier);

	public const string WindThreat = nameof(WindThreat);
	public const string MaxWindGust = nameof(MaxWindGust);

	public const string HailThreat = nameof(HailThreat);
	public const string MaxHailSize = nameof(MaxHailSize);

	public const string ThunderstormDamageThreat = nameof(ThunderstormDamageThreat);

	public const string TornadoDamageThreat = nameof(TornadoDamageThreat);
	public const string TornadoDetection = nameof(TornadoDetection);
	public const string WaterspoutDetection = nameof(WaterspoutDetection);

	public const string FlashFloodDamageThreat = nameof(FlashFloodDamageThreat);
	public const string FlashFloodDetection = nameof(FlashFloodDetection);

	public const string SnowSquallDetection = nameof(SnowSquallDetection);
	public const string SnowSquallImpact = nameof(SnowSquallImpact);
}

public static class AlertParameterValues
{
	public const string RadarIndicated = "Radar Indicated";
	public const string RadarAndGaugeIndicated = "Radar and Gauge Indicated";
	public const string Possible = "Possible";
	public const string Observed = "Observed";
	public const string Considerable = "Considerable";
	public const string Catastrophic = "Catastrophic";
	public const string Destructive = "Destructive";
	public const string Significant = "Significant";
	public const string ParticularlyDangerousSituation = "PDS";
	public const string Emergency = "Emergency";
}
