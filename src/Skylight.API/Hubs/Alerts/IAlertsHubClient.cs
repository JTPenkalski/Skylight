using Skylight.API.Hubs.Alerts.Events;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.API.Hubs.Alerts;

/// <summary>
/// Client contract for updates sent about <see cref="Alert"/>s.
/// </summary>
public interface IAlertsHubClient
{
	Task NotifyNewAlertsAsync(NotifyNewAlertsInput input);

	Task NotifyExpiredAlertsAsync(NotifyExpiredAlertsInput input);
}
