using Skylight.Domain.Alerts.Entities;

namespace Skylight.Application.Services;

/// <summary>
/// Retrieves real-time weather alert information.
/// </summary>
public interface IWeatherAlertService
{
	/// <summary>
	/// Determines all currently active weather alerts.
	/// </summary>
	/// <returns>A collection of all currently active weather alerts</returns>
	Task<IEnumerable<Alert>> GetActiveAlertsAsync(CancellationToken cancellationToken);
}
