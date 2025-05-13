namespace Skylight.Infrastructure.Hubs.Events;

public sealed record NotifyNewAlertsInput(int Count) : IHubInput;
