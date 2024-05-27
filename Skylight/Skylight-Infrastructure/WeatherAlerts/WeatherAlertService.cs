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
			Statuses: [AlertStatus.Actual],
			MessageTypes: [AlertMessageType.Alert]);

		GetActiveAlertsResponse clientResponse = await nwsClient.GetActiveAlertsAsync(clientRequest, cancellationToken);
		HashSet<string> alertNames = clientResponse.AlertCollection.Alerts.Select(x => x.Event).ToHashSet();
		Dictionary<string, WeatherAlert> weatherAlerts = await context.WeatherAlerts
			.Where(x => alertNames.Contains(x.Name))
			.ToDictionaryAsync(x => x.Name, cancellationToken);

		foreach (Alert alert in clientResponse.AlertCollection.Alerts)
		{
			if (weatherAlerts.TryGetValue(alert.Event, out WeatherAlert? weatherAlert))
			{
				var weatherEventAlert = new WeatherEventAlert
				{
					Sender = alert.SenderName,
					Headline = alert.Headline ?? string.Empty,
					Instruction = alert.Instruction ?? string.Empty,
					Description = alert.Description,
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
