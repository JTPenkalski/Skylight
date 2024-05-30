using Skylight.Domain.Entities;

namespace Skylight.Application.Interfaces.Infrastructure;

/// <summary>
/// Retrieves real-time Weather Alerts from the National Weather Service.
/// </summary>
public interface IWeatherAlertService
{
	/// <summary>
	/// Queries all active NWS Alerts for <paramref name="weatherEvent"/>.
	/// </summary>
	/// <param name="weatherEvent">The <see cref="WeatherEvent"/> to find Alerts for.</param>
	/// <returns></returns>
	Task<IEnumerable<WeatherEventAlert>> GetActiveAlertsForEventAsync(WeatherEvent weatherEvent, CancellationToken cancellationToken);
}
