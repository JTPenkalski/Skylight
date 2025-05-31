namespace Skylight.API.Hubs.Alerts.Events;

public sealed record NotifyExpiredAlertsInput(int Count) : IHubInput;
