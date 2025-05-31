using Microsoft.AspNetCore.SignalR;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.API.Hubs.Alerts;

/// <summary>
/// Client/Server connection hub for updates to <see cref="Alert"/>s.
/// </summary>
public class AlertsHub : Hub<IAlertsHubClient>;
