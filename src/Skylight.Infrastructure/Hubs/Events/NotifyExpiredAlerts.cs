namespace Skylight.Infrastructure.Hubs.Events;

public sealed record NotifyExpiredAlertsInput(int Count) : IHubInput;
