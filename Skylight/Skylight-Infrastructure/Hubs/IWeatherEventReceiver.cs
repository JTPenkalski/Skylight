namespace Skylight.Infrastructure.Hubs;

/// <summary>
/// Contract for notifying clients of server updates related to <see cref="Domain.Entities.WeatherEvent"/> events.
/// </summary>
public interface IWeatherEventReceiver
{
	Task ReceiveNewWeatherAlerts(string message);
}
