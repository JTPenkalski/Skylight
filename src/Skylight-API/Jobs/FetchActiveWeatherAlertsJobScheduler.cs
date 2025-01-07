using Hangfire;
using Microsoft.Extensions.Options;
using Skylight.Infrastructure.Jobs;

namespace Skylight.API.Jobs;

public class FetchActiveWeatherAlertsJobScheduler(IOptions<FetchActiveWeatherAlertsJobOptions> options) : BaseJobScheduler<FetchActiveWeatherAlertsJob>
{
	public override string CronSchedule =>
		options.Value.Enabled
			? Cron.Minutely()
			: Cron.Never();
}
