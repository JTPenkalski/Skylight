using Skylight.Domain.Alerts.Entities;
using Skylight.Infrastructure.Hubs.Events;

namespace Skylight.Infrastructure.Hubs;

/// <summary>
/// Client contract for updates sent about <see cref="Alert"/>s.
/// </summary>
public interface IAlertsHubClient
{
	Task NotifyNewAlertsAsync(NotifyNewAlertsInput input);
}
