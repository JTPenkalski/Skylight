using Microsoft.AspNetCore.SignalR;

namespace Skylight.Infrastructure.Hubs.WeatherEvent;

/// <summary>
/// Connection hub between client/server for <see cref="Domain.Entities.WeatherEvent"/> events.
/// </summary>
public class WeatherEventHub : Hub<IWeatherEventReceiver>
{
	
}
