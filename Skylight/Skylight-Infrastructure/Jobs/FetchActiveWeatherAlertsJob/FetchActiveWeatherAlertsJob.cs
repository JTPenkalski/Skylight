using FluentResults;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.UseCases.WeatherEvents.Commands;
using Skylight.Domain.Entities;
using Skylight.Infrastructure.Hubs.WeatherEvent;
using Skylight.Infrastructure.Hubs.WeatherEvent.Requests;

namespace Skylight.Infrastructure.Jobs;

/// <summary>
/// Retrieves all Weather Alerts from the NWS for all active <see cref="WeatherEvent"/> instances.
/// </summary>
public sealed class FetchActiveWeatherAlertsJob(
	ILogger<FetchActiveWeatherAlertsJob> logger,
	ISkylightContext dbContext,
	IHubContext<WeatherEventHub, IWeatherEventReceiver> hubContext,
	IMediator mediator) : IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		IEnumerable<WeatherEvent> activeEvents = await dbContext.WeatherEvents
			.Where(x => !x.EndDate.HasValue)
			.ToListAsync(cancellationToken);

		if (activeEvents.Any())
		{
			var newAlerts = new List<ReceiveNewWeatherAlertsRequest.NewWeatherEventAlert>();

			foreach (WeatherEvent activeEvent in activeEvents)
			{
				var newAlertsForEvent = await GetActiveAlertsForEventAsync(activeEvent, cancellationToken);

				newAlerts.AddRange(newAlertsForEvent);
			}

			var request = new ReceiveNewWeatherAlertsRequest
			{
				NewWeatherEventAlerts = newAlerts
			};

			await hubContext.Clients.All.ReceiveNewWeatherAlerts(request);
		}
		else
		{
			logger.LogInformation("Found 0 active Weather Events to retrieve Weather Alerts for. IsSuccess = true!");
		}		
	}

	private async Task<IEnumerable<ReceiveNewWeatherAlertsRequest.NewWeatherEventAlert>> GetActiveAlertsForEventAsync(WeatherEvent activeEvent, CancellationToken cancellationToken)
	{
		var command = new FetchWeatherAlertsCommand(activeEvent.Id);

		Result<FetchWeatherAlertsResponse> result = await mediator.Send(command, cancellationToken);

		var newAlertsForEvent = result.Value.NewWeatherEventAlerts
			.Select(x => new ReceiveNewWeatherAlertsRequest.NewWeatherEventAlert(
				x.Sender,
				x.Headline,
				x.Instruction,
				x.Description,
				x.Sent,
				x.Effective,
				x.Expires,
				x.Name,
				x.Source,
				x.Level,
				x.Code))
			.ToList();

		logger.LogInformation("Retrieved {Count} Weather Alerts for the {Name} Weather Event. IsSuccess = {Result}!",
			newAlertsForEvent.Count,
			activeEvent.Name,
			result.IsSuccess);

		return newAlertsForEvent;
	}
}
