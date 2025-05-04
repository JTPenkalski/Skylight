using Hangfire;
using Mediator;
using Microsoft.Extensions.Options;
using Skylight.Application.Features.Alerts.Commands;
using Skylight.Infrastructure.Jobs;
using Skylight.Infrastructure.Jobs.Schedules;

namespace Skylight.API.Jobs;

public class AddCurrentWeatherAlertsJobSchedulerOptions : IJobSchedulerOptions
{
	public const string RootKey = $"Jobs:{nameof(AddCurrentWeatherAlertsJob)}";

	public bool Enabled { get; set; }

	public string Schedule { get; set; } = Cron.Never();
}

public class AddCurrentWeatherAlertsJobScheduler(IOptions<AddCurrentWeatherAlertsJobSchedulerOptions> options)
	: BaseJobScheduler<AddCurrentWeatherAlertsJob>
{
	public override bool TriggerImmediate => true;

	public override string CronSchedule =>
		options.Value.Enabled
			? options.Value.Schedule
			: Cron.Never();
}

public sealed class AddCurrentWeatherAlertsJob(IMediator mediator) : IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		var newAlertsRequest = new AddCurrentAlertsCommand();
		await mediator.Send(newAlertsRequest, cancellationToken);
	}
}
