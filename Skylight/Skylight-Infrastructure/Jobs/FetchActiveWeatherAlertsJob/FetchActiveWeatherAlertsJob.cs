using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.UseCases.WeatherEvents.Commands;
using Skylight.Domain.Entities;

namespace Skylight.Infrastructure.Jobs;

/// <summary>
/// Retrieves all Weather Alerts from the NWS for all active <see cref="WeatherEvent"/> instances.
/// </summary>
public class FetchActiveWeatherAlertsJob(
	ILogger<FetchActiveWeatherAlertsJob> logger,
	IOptions<FetchActiveWeatherAlertsJobOptions> options,
	ISkylightContext context,
	IMediator mediator) : IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		if (!options.Value.Enabled) return;

		IEnumerable<WeatherEvent> activeEvents = await context.WeatherEvents
			.Where(x => !x.EndDate.HasValue)
			.ToListAsync(cancellationToken);

		if (activeEvents.Any())
		{
			foreach (WeatherEvent activeEvent in activeEvents)
			{
				var request = new FetchWeatherAlertsCommand(activeEvent.Id);

				Result<FetchWeatherAlertsResponse> result = await mediator.Send(request, cancellationToken);

				logger.LogInformation("Retrieved {Count} Weather Alerts for the {Name} Weather Event. IsSuccess = {Result}!",
					result.Value.NewWeatherEventAlerts.Count(),
					activeEvent.Name,
					result.IsSuccess);
			}
		}
		else
		{
			logger.LogInformation("Found 0 active Weather Events to retrieve Weather Alerts for. IsSuccess = true!");
		}		
	}
}
