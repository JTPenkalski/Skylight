using Hangfire;
using Microsoft.Extensions.Options;
using Skylight.Infrastructure.Jobs;

namespace Skylight.API.Jobs;

public class PublishDomainEventsJobScheduler(IOptions<PublishDomainEventsJobOptions> options) : BaseJobScheduler<PublishDomainEventsJob>
{
	public override string CronSchedule =>
		options.Value.Enabled
			? Cron.Minutely()
			: Cron.Never();
}
