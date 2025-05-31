namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// A unique NWS Zone.
/// </summary>
public sealed record Zone(
	UgcZone Id,
	ZoneType Type,
	string Name,
	string? State)
{
	public string FullName
	{
		get
		{
			string fullName = Name;

			if (!string.IsNullOrWhiteSpace(State))
			{
				fullName += $", {State}";
			}

			return fullName;
		}
	}
}
