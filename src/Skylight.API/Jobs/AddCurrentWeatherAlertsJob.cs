using Hangfire;
using Mediator;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Skylight.API.Hubs;
using Skylight.Application.Features.Alerts.Commands;
using Skylight.Domain.Common.Results;
using Skylight.Infrastructure.Hubs;
using Skylight.Infrastructure.Hubs.Events;
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

public sealed class AddCurrentWeatherAlertsJob(
	ILogger<AddCurrentWeatherAlertsJob> logger,
	IMediator mediator,
	IHubContext<AlertsHub, IAlertsHubClient> hub)
	: IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		Result<AddCurrentAlertsResponse> result = await AddCurrentAlertsAsync(cancellationToken);

		if (result.TryGetValue(out AddCurrentAlertsResponse? currentAlerts))
		{
			logger.LogInformation(
				"Successfully added {AlertCount} current alerts. {Result}",
				currentAlerts.AddedAlerts.Count(),
				result);

			await NotifyClientsAsync(currentAlerts);
		}
		else
		{
			logger.LogError("Failed to add current alerts. {Result}", result);
		}
	}

	internal async Task<Result<AddCurrentAlertsResponse>> AddCurrentAlertsAsync(CancellationToken cancellationToken)
	{
		var request = new AddCurrentAlertsCommand();
		var response = await mediator.Send(request, cancellationToken);

		return response;
	}

	internal async Task NotifyClientsAsync(AddCurrentAlertsResponse currentAlerts)
	{
		int addedAlerts = currentAlerts.AddedAlerts.Count();

		if (addedAlerts > 0)
		{
			var input = new NotifyNewAlertsInput(addedAlerts);

			await hub.Clients.All.NotifyNewAlertsAsync(input);
		}
	}
}
