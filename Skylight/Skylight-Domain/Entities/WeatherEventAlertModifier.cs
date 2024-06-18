namespace Skylight.Domain.Entities;

public class WeatherEventAlertModifier : BaseAuditableEntity
{
	public required virtual WeatherEventAlert Alert { get; set; }

	public required virtual WeatherAlertModifier Modifier { get; set; }
}
