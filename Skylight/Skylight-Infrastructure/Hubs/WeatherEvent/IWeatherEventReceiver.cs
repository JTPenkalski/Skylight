using Skylight.Infrastructure.Hubs.WeatherEvent.Requests;

namespace Skylight.Infrastructure.Hubs.WeatherEvent;

/// <summary>
/// Contract for notifying clients of server updates related to <see cref="Domain.Entities.WeatherEvent"/> events.
/// </summary>
public interface IWeatherEventReceiver
{
	Task ReceiveNewWeatherAlerts(ReceiveNewWeatherAlertsRequest request);
}
