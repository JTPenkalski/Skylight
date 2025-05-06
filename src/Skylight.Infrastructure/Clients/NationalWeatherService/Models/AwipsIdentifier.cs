namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Advanced Weather Interactive Processing System (AWIPS) identifier.
/// </summary>
/// <remarks>
/// Of the form AAABBB, where AAA is the product category and BBB is the office identifier.
/// </remarks>
public sealed record AwipsIdentifier(string ProductCategory, string OfficeIdentifier)
{
	public static AwipsIdentifier Parse(string value)
	{
		string productCategory = value[0..3];
		string officeIdentifier = value[3..];

		return new(productCategory, officeIdentifier);
	}
}
