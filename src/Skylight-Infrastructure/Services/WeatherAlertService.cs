using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;
using Skylight.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Clients.NationalWeatherService.Actions;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;

namespace Skylight.Infrastructure.Services;

public class WeatherAlertService(
	ISkylightContext dbContext,
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

		HashSet<string> alertNames = clientResponse.AlertCollection.Alerts
			.Select(x => x.Event)
			.ToHashSet();
		Dictionary<string, WeatherAlert> weatherAlerts = await dbContext.WeatherAlerts
			.Where(x => alertNames.Contains(x.Name))
			.ToDictionaryAsync(x => x.Name, cancellationToken);

		HashSet<string> alertLocations = clientResponse.AlertCollection.Alerts
			.SelectMany(x => x.ZoneIds)
			.ToHashSet();
		Dictionary<string, Location> locations = (await GetLocationsForAlertAsync(alertLocations, cancellationToken))
			.ToDictionary(x => x.ExternalId!);

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
					ExternalId = alert.Id,
					Event = weatherEvent,
					Alert = weatherAlert,
				};

				foreach (string zoneId in alert.ZoneIds)
				{
					weatherEventAlert.AddLocation(locations[zoneId]);
				}

				eventAlerts.Add(weatherEventAlert);
			}
		}

		return eventAlerts;
	}

	protected async Task<IEnumerable<Location>> GetLocationsForAlertAsync(IEnumerable<string> zoneIds, CancellationToken cancellationToken)
	{
		var locations = new List<Location>();

		var clientRequest = new GetZonesRequest(
			ZoneIds: zoneIds.ToArray(),
			ZoneTypes: [ZoneType.Public, ZoneType.County]);

		GetZonesResponse response = await nwsClient.GetZonesAsync(clientRequest, cancellationToken);

		foreach (Zone zone in response.Zones)
		{
			Location location = await dbContext.Locations.FirstOrDefaultAsync(x => x.ExternalId == zone.Id, cancellationToken)
				?? new Location
				{
					Name = zone.Name,
					State = zone.State,
					ExternalId = zone.Id,
				};

			locations.Add(location);
		}

		return locations;
	}
}
