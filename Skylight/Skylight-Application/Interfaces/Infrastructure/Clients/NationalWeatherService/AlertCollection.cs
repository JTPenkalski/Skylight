namespace Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;

/// <summary>
/// A group of <see cref="Alert"/> instances.
/// </summary>
public record AlertCollection(
    string Title,
    DateTimeOffset Updated,
    IReadOnlyList<Alert> Alerts);
