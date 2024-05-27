using Hangfire;
using Skylight.Infrastructure.Jobs;

namespace Skylight.Jobs;

public class FetchActiveWeatherAlertsJobScheduler : BaseJobScheduler<FetchActiveWeatherAlertsJob>
{
	public override string CronSchedule => Cron.Minutely();
}
