namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// A group of <see cref="Alert"/> instances.
/// </summary>
public sealed record AlertCollection(
	string Title,
	DateTimeOffset Updated,
	IReadOnlyList<Alert> Alerts);
