using Microsoft.Extensions.Options;

namespace Skylight.Infrastructure.Clients.NationalWeatherService;

public class NationalWeatherServiceClientOptions : IOptions<NationalWeatherServiceClientOptions>
{
	public const string RootKey = "Clients:NationalWeatherServiceClient";

	public NationalWeatherServiceClientOptions Value => this;

	public string BaseUrl { get; set; } = string.Empty;

	public string UserAgent { get; set; } = string.Empty;
}
