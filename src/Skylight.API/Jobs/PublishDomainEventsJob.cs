using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Skylight.Application.Data;
using Skylight.Application.Events;
using Skylight.Domain.Common.Events;
using Skylight.Infrastructure.Jobs;
using Skylight.Infrastructure.Jobs.Schedules;

namespace Skylight.API.Jobs;

public class PublishDomainEventsJobSchedulerOptions : IJobSchedulerOptions
{
	public const string RootKey = $"Jobs:{nameof(PublishDomainEventsJob)}";

	public bool Enabled { get; set; }

	public string Schedule { get; set; } = Cron.Never();
}

public class PublishDomainEventsJobScheduler(IOptions<PublishDomainEventsJobSchedulerOptions> options)
	: BaseJobScheduler<PublishDomainEventsJob>
{
	public override bool TriggerImmediate => true;

	public override string CronSchedule =>
		options.Value.Enabled
			? options.Value.Schedule
			: Cron.Never();
}

public sealed class PublishDomainEventsJob(
	ILogger<PublishDomainEventsJob> logger,
	ISkylightDbContext dbContext,
	IDomainEventService domainEventService)
	: IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		List<Event> events = await dbContext.Events
			.Where(x => !x.HandledOn.HasValue)
			.ToListAsync(cancellationToken);

		int successfulEvents = 0;

		foreach (Event e in events)
		{
			try
			{
				await domainEventService.PublishDomainEventAsync(e, cancellationToken);

				e.Succeed();

				successfulEvents++;
			}
			catch (Exception ex)
			{
				e.Fail();

				logger.LogError(
					ex,
					"Failed to process '{EventType}' Event {EventId}. Total Failures = {EventFailures}",
					e.Type,
					e.Id,
					e.Failures);
			}
			finally
			{
				await dbContext.CommitAsync(cancellationToken);
			}
		}
	}
}
