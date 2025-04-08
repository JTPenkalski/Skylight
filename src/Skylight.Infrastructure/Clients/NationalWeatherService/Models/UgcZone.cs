namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// A Universal Geographic Code, as defined by the NWS.
/// </summary>
/// <remarks>
/// Of the form AABCCC, where AA is the <see cref="StateTerritoryCode"/>/<see cref="MarineAreaCode"/>, B is the <see cref="UgcZoneType"/>, and C is the zone number.
/// </remarks>
public sealed record UgcZone(
	string AreaCode,
	UgcZoneType Type,
	int Number)
{
	public static UgcZone Parse(string value)
	{
		string areaCode = value[0..2];
		UgcZoneType type = value[2].ToUgcZoneType();
		int number = int.Parse(value[3..]);

		return new(areaCode, type, number);
	}

	public override string ToString() =>
		$"{AreaCode}{Type.ToCharacter()}{Number:D3}";

	public override int GetHashCode() =>
		HashCode.Combine(
			AreaCode.GetHashCode(),
			Type.GetHashCode(),
			Number.GetHashCode());
};
