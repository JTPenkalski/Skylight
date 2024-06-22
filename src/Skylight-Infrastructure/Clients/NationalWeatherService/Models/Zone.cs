namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// A unique NWS Zone.
/// </summary>
public sealed record Zone(
	string Id,
	ZoneType Type,
	string Name,
	string? State);
