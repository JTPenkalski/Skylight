using Microsoft.AspNetCore.SignalR;
using Skylight.Domain.Alerts.Entities;
using Skylight.Infrastructure.Hubs;

namespace Skylight.API.Hubs;

/// <summary>
/// Client/Server connection hub for updates to <see cref="Alert"/>s.
/// </summary>
public class AlertsHub : Hub<IAlertsHubClient>;
