using Hangfire;
using Mediator;
using Microsoft.Extensions.Options;
using Skylight.Application.Alerts.Commands;
using Skylight.Infrastructure.Jobs;
using Skylight.Infrastructure.Jobs.Schedules;

namespace Skylight.API.Jobs;

public class DeleteHistoricalAlertsJobSchedulerOptions : IJobSchedulerOptions
{
	public const string RootKey = $"Jobs:{nameof(DeleteHistoricalAlertsJob)}";

	public bool Enabled { get; set; }

	public string Schedule { get; set; } = Cron.Never();

	public int Threshold { get; set; } = 24;
}

public class DeleteHistoricalAlertsJobScheduler(IOptions<DeleteHistoricalAlertsJobSchedulerOptions> options)
	: BaseJobScheduler<DeleteHistoricalAlertsJob, DeleteHistoricalAlertsJobArguments>
{
	public override bool TriggerImmediate => true;

	public override DeleteHistoricalAlertsJobArguments Arguments =>
		new(options.Value.Threshold);

	public override string CronSchedule =>
		options.Value.Enabled
			? options.Value.Schedule
			: Cron.Never();
}

public record DeleteHistoricalAlertsJobArguments(int Threshold);

public sealed class DeleteHistoricalAlertsJob(
	ILogger<DeleteHistoricalAlertsJob> logger,
	IMediator mediator)
	: IJob<DeleteHistoricalAlertsJobArguments>
{
	public async Task ProcessAsync(DeleteHistoricalAlertsJobArguments arguments, CancellationToken cancellationToken)
	{
		logger.LogInformation("Attempting to delete historical data from the last {Threshold} hours.", arguments.Threshold);

		var result = await mediator.Send(new DeleteHistoricalAlertsCommand(arguments.Threshold), cancellationToken);

		if (result.TryGetValue(out DeleteHistoricalAlertsResponse? deletedHistoricalAlerts))
		{
			logger.LogInformation(
				"Successfully deleted {DeletedAlerts} alerts and {DeletedEvents} events. {Result}",
				deletedHistoricalAlerts.AlertCount,
				deletedHistoricalAlerts.EventCount,
				result);
		}
		else
		{
			logger.LogError("Failed to delete historical data. {Result}", result);
		}
	}
}
