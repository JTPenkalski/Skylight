using Microsoft.Extensions.Options;

namespace Skylight.Infrastructure.Jobs;

public class FetchActiveWeatherAlertsJobOptions : IOptions<FetchActiveWeatherAlertsJobOptions>
{
	public const string RootKey = "Jobs:FetchActiveWeatherAlertsJob";

	public FetchActiveWeatherAlertsJobOptions Value => this;

	public bool Enabled { get; set; } = false;
}
