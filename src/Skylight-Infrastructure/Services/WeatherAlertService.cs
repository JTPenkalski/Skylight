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

		// Get all Alerts
		var clientRequest = new GetActiveAlertsRequest(
			Statuses: [AlertStatus.Actual],
			MessageTypes: [AlertMessageType.Alert]);

		GetActiveAlertsResponse clientResponse = await nwsClient.GetActiveAlertsAsync(clientRequest, cancellationToken);

		IEnumerable<Alert> alerts = clientResponse.AlertCollection.Alerts.ToList();
		HashSet<string> alertNames = alerts
			.Select(x => x.Event)
			.ToHashSet();

		// Get all Alert Types
		Dictionary<string, WeatherAlert> weatherAlerts = await dbContext.WeatherAlerts
			.Where(x => alertNames.Contains(x.Name))
			.ToDictionaryAsync(x => x.Name, cancellationToken);

		// Get all Locations
		Dictionary<string, Location> locations = await GetLocationsAsync(alerts, cancellationToken);

		// Store all Event Alerts
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
					if (locations.TryGetValue(zoneId, out Location? location))
					{
						weatherEventAlert.AddLocation(location);
					}
				}

				eventAlerts.Add(weatherEventAlert);
			}
		}

		return eventAlerts;
	}

	internal async Task<Dictionary<string, Location>> GetLocationsAsync(IEnumerable<Alert> alerts, CancellationToken cancellationToken)
	{
		// Find all existing Locations
		HashSet<string> zoneIds = alerts
			.SelectMany(x => x.ZoneIds)
			.ToHashSet();

		Dictionary<string, Location> locations = await dbContext.Locations
			.Where(x => x.ExternalId != null && zoneIds.Contains(x.ExternalId))
			.ToDictionaryAsync(x => x.ExternalId!, cancellationToken);

		IEnumerable<string[]> zoneIdChunks = zoneIds
			.Except(locations.Keys)
			.Chunk(500);

		foreach (string[] zoneIdChunk in zoneIdChunks)
		{
			// Get all new Locations
			var clientRequest = new GetZonesRequest(
				ZoneIds: zoneIdChunk,
				ZoneTypes: [ZoneType.Public, ZoneType.County]);

			GetZonesResponse response = await nwsClient.GetZonesAsync(clientRequest, cancellationToken);

			// Store all new Locations
			foreach (Zone zone in response.Zones)
			{
				var location = new Location
				{
					Name = zone.Name,
					State = zone.State,
					ExternalId = zone.Id,
				};

				locations.Add(zone.Id, location);
			}
		}

		return locations;
	}
}
