using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Alerts.Entities;

public class AlertType : BaseAuditableEntity
{
	public required string ProductCode { get; set; }

	public required string Name { get; set; }

	public required string Description { get; set; }

	public required AlertLevel Level { get; set; }

	public string? EventCode { get; set; }

	public string TypeCode
	{
		get => EventCode ?? ProductCode;
		protected set => EventCode ??= value;
	}
}

public static class AlertTypeCodes
{
	public const string TornadoWarning = "TOW";
	public const string SevereThunderstormWarning = "SVW";
	public const string FlashFloodWarning = "FFW";
	public const string SpecialWeatherStatement = "SPS";
}
