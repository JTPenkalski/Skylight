using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;
using Skylight.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Clients.NationalWeatherService.Actions;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;

namespace Skylight.Infrastructure.WeatherAlerts;

public class WeatherAlertService(
	ISkylightContext context,
	INationalWeatherServiceClient nwsClient)
	: IWeatherAlertService
{
	public async Task<IEnumerable<WeatherEventAlert>> GetActiveAlertsForEventAsync(WeatherEvent weatherEvent, CancellationToken cancellationToken)
	{
		var eventAlerts = new List<WeatherEventAlert>();

		var clientRequest = new GetActiveAlertsRequest(
			Status: AlertStatus.Actual,
			Urgency: AlertUrgency.Immediate);

		GetActiveAlertsResponse clientResponse = await nwsClient.GetActiveAlertsAsync(clientRequest, cancellationToken);

		foreach (Alert alert in clientResponse.AlertCollection.Alerts)
		{
			WeatherAlert? weatherAlert = await context.WeatherAlerts
				.FirstOrDefaultAsync(x => x.Name == alert.Event, cancellationToken);

			if (weatherAlert is not null)
			{
				var weatherEventAlert = new WeatherEventAlert
				{
					Sent = alert.Sent,
					Effective = alert.Effective,
					Onset = alert.Onset,
					Expires = alert.Expires,
					Ends = alert.Ends,
					Event = weatherEvent,
					Alert = weatherAlert,
				};

				eventAlerts.Add(weatherEventAlert);
			}
		}

		return eventAlerts;
	}
}
