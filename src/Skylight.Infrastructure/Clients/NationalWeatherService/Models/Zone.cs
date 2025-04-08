namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// A unique NWS Zone.
/// </summary>
public sealed record Zone(
	UgcZone Id,
	ZoneType Type,
	string Name,
	string? State);
