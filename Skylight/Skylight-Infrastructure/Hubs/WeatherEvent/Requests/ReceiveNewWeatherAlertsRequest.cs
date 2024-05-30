using Skylight.Domain.Entities;

namespace Skylight.Infrastructure.Hubs.WeatherEvent.Requests;

public sealed record ReceiveNewWeatherAlertsRequest
{
	public required IEnumerable<NewWeatherEventAlert> NewWeatherEventAlerts { get; init; }

	public sealed record NewWeatherEventAlert(
		string Sender,
		string Headline,
		string Instruction,
		string Description,
		DateTimeOffset Sent,
		DateTimeOffset Effective,
		DateTimeOffset Expires,
		string Name,
		string Source,
		WeatherAlertLevel Level,
		string? Code = null);
}

