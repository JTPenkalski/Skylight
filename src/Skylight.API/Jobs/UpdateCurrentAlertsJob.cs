using Hangfire;
using Mediator;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Skylight.API.Hubs;
using Skylight.Application.Features.Alerts.Commands;
using Skylight.Infrastructure.Hubs;
using Skylight.Infrastructure.Hubs.Events;
using Skylight.Infrastructure.Jobs;
using Skylight.Infrastructure.Jobs.Schedules;

namespace Skylight.API.Jobs;

public class UpdateCurrentAlertsJobSchedulerOptions : IJobSchedulerOptions
{
	public const string RootKey = $"Jobs:{nameof(UpdateCurrentAlertsJob)}";

	public bool Enabled { get; set; }

	public string Schedule { get; set; } = Cron.Never();
}

public class UpdateCurrentAlertsJobScheduler(IOptions<UpdateCurrentAlertsJobSchedulerOptions> options)
	: BaseJobScheduler<UpdateCurrentAlertsJob>
{
	public override bool TriggerImmediate => true;

	public override string CronSchedule =>
		options.Value.Enabled
			? options.Value.Schedule
			: Cron.Never();
}

public sealed class UpdateCurrentAlertsJob(
	ILogger<UpdateCurrentAlertsJob> logger,
	IMediator mediator,
	IHubContext<AlertsHub, IAlertsHubClient> hub)
	: IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		await AddNewAlertsAsync(cancellationToken);
		await ExpireCurrentAlertsAsync(cancellationToken);
	}

	internal async Task AddNewAlertsAsync(CancellationToken cancellationToken)
	{
		var result = await mediator.Send(new AddNewAlertsCommand(), cancellationToken);

		if (result.TryGetValue(out AddNewAlertsResponse? newAlerts))
		{
			int newAlertsCount = newAlerts.AddedAlerts.Count();

			logger.LogInformation(
				"Successfully found {NewAlertCount} new alerts. {Result}",
				newAlertsCount,
				result);

			if (newAlertsCount > 0)
			{
				var input = new NotifyNewAlertsInput(newAlertsCount);

				await hub.Clients.All.NotifyNewAlertsAsync(input);
			}
		}
		else
		{
			logger.LogError("Failed to add new alerts. {Result}", result);
		}
	}

	internal async Task ExpireCurrentAlertsAsync(CancellationToken cancellationToken)
	{
		var result = await mediator.Send(new ExpireCurrentAlertsCommand(), cancellationToken);

		if (result.TryGetValue(out ExpireCurrentAlertsResponse? expiredAlerts))
		{
			int expiredAlertsCount = expiredAlerts.Count;

			logger.LogInformation(
				"Successfully found {ExpiredAlertCount} expired alerts. {Result}",
				expiredAlertsCount,
				result);

			if (expiredAlertsCount > 0)
			{
				var input = new NotifyExpiredAlertsInput(expiredAlertsCount);

				await hub.Clients.All.NotifyExpiredAlertsAsync(input);
			}
		}
		else
		{
			logger.LogError("Failed to expire current alerts. {Result}", result);
		}
	}
}
