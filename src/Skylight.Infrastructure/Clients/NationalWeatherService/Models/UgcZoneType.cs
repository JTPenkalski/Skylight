namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Alert UGC zone type.
/// </summary>
public enum UgcZoneType
{
	PublicFire,
	County
}

public static class UgcZoneTypeExtensions
{
	public const char PublicFireCode = 'Z';
	public const char CountyCode = 'C';

	public static char ToCharacter(this UgcZoneType type) =>
		type switch
		{
			UgcZoneType.PublicFire => PublicFireCode,
			UgcZoneType.County => CountyCode,
			_ => throw new InvalidCastException($"Cannot convert {type} to character code!")
		};

	public static UgcZoneType ToUgcZoneType(this char code) =>
		code switch
		{
			PublicFireCode => UgcZoneType.PublicFire,
			CountyCode => UgcZoneType.County,
			_ => throw new InvalidCastException($"Cannot convert {code} into {nameof(UgcZoneType)}!")
		};
}
