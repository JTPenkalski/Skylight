namespace Skylight.API.Hubs.Alerts.Events;

public sealed record NotifyNewAlertsInput(int Count) : IHubInput;
