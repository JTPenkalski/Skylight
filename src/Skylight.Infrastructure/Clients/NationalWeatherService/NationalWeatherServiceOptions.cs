namespace Skylight.Infrastructure.Clients.NationalWeatherService;

public class NationalWeatherServiceOptions
{
	public const string RootKey = "Clients:NationalWeatherService";

	public string BaseUrl { get; set; } = string.Empty;

	public string UserAgent { get; set; } = string.Empty;
}
