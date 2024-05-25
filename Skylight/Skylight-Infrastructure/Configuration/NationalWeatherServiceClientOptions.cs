using Microsoft.Extensions.Options;

namespace Skylight.Infrastructure.Configuration;

public class NationalWeatherServiceClientOptions : IOptions<NationalWeatherServiceClientOptions>
{
    public const string RootKey = "NationalWeatherServiceClient";

    public NationalWeatherServiceClientOptions Value => this;

    public string BaseUrl { get; set; } = string.Empty;

    public string UserAgent { get; set; } = string.Empty;
}
