using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Services;
using Skylight.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Clients.NationalWeatherService.Endpoints;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using Core = Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Services;

public class WeatherAlertService(
	ISkylightDbContext dbContext,
	INationalWeatherServiceClient nwsClient)
	: IWeatherAlertService
{
	public async Task<IEnumerable<Core.Alert>> GetActiveAlertsAsync(CancellationToken cancellationToken)
	{
		var clientRequest = new GetActiveAlertsRequest(
			Statuses: [AlertStatus.Actual],
			MessageTypes: [AlertMessageType.Alert]);

		GetActiveAlertsResponse clientResponse = await nwsClient.GetActiveAlertsAsync(clientRequest, cancellationToken);

		List<Alert> alerts = [.. clientResponse.AlertCollection.Alerts];
		Dictionary<string, Core.AlertType> alertTypes = await GetAlertTypesAsync(alerts, cancellationToken);
		Dictionary<string, Core.AlertSender> alertSenders = await GetAlertSendersAsync(alerts, cancellationToken);
		Dictionary<string, Core.AlertZone> alertZones = await GetAlertZonesAsync(alerts, cancellationToken);

		return MapCurrentAlerts(clientResponse, alertTypes, alertSenders, alertZones);
	}

	internal async Task<Dictionary<string, Core.AlertType>> GetAlertTypesAsync(List<Alert> alerts, CancellationToken cancellationToken)
	{
		HashSet<string> typeNames = [.. alerts.Select(x => x.AwipsId.ProductCategory)];
		Dictionary<string, Core.AlertType> types = await dbContext.AlertTypes
			.Where(x => typeNames.Contains(x.Code))
			.ToDictionaryAsync(x => x.Code, cancellationToken);

		return types;
	}

	internal async Task<Dictionary<string, Core.AlertSender>> GetAlertSendersAsync(List<Alert> alerts, CancellationToken cancellationToken)
	{
		HashSet<string> senderNames = [.. alerts.Select(x => x.AwipsId.OfficeIdentifier)];
		Dictionary<string, Core.AlertSender> senders = await dbContext.AlertSenders
			.Where(x => senderNames.Contains(x.Code))
			.ToDictionaryAsync(x => x.Code, cancellationToken);

		return senders;
	}

	internal async Task<Dictionary<string, Core.AlertZone>> GetAlertZonesAsync(IEnumerable<Alert> alerts, CancellationToken cancellationToken)
	{
		HashSet<string> allZones = [.. alerts.SelectMany(x => x.Zones.Select(x => x.ToString()))];

		Dictionary<string, Core.AlertZone> knownZones = await dbContext.AlertZones
			.Where(x => allZones.Contains(x.Code))
			.ToDictionaryAsync(x => x.Code, cancellationToken);

		IEnumerable<string[]> unknownZoneChunks = allZones
			.Except(knownZones.Keys)
			.Chunk(500);

		foreach (string[] unknownZones in unknownZoneChunks)
		{
			var clientRequest = new GetZonesRequest(
				ZoneIds: unknownZones,
				ZoneTypes: [ZoneType.Public, ZoneType.County]);

			GetZonesResponse response = await nwsClient.GetZonesAsync(clientRequest, cancellationToken);

			foreach (Zone zone in response.Zones)
			{
				var newZone = new Core.AlertZone
				{
					Code = zone.Id.ToString(),
					State = zone.State,
				};

				knownZones.Add(newZone.Code, newZone);
			}
		}

		return knownZones;
	}

	internal static List<Core.Alert> MapCurrentAlerts(GetActiveAlertsResponse clientResponse, Dictionary<string, Core.AlertType> alertTypes, Dictionary<string, Core.AlertSender> alertSenders, Dictionary<string, Core.AlertZone> alertZones)
	{
		var currentAlerts = new List<Core.Alert>();

		foreach (Alert alert in clientResponse.AlertCollection.Alerts)
		{
			if (alertTypes.TryGetValue(alert.AwipsId.ProductCategory, out Core.AlertType? alertType))
			{
				// TODO: Actually populate Senders in the database as static data
				Core.AlertSender alertSender = alertSenders.TryGetValue(alert.SenderName, out Core.AlertSender? value)
					? value
					: new Core.AlertSender { Code = "TEST", Name = alert.SenderName };

				var currentAlert = new Core.Alert
				{
					Type = alertType,
					Sender = alertSender,
					Headline = alert.Headline ?? string.Empty,
					Description = alert.Description,
					Instruction = alert.Instruction ?? string.Empty,
					SentOn = alert.Sent,
					EffectiveOn = alert.Effective,
					BeginsOn = alert.Onset ?? alert.Effective,
					ExpiresOn = alert.Expires,
					EndsOn = alert.Ends ?? alert.Expires,
					MessageType = alert.MessageType.ToCore(),
					Severity = alert.Severity.ToCore(),
					Certainty = alert.Certainty.ToCore(),
					Urgency = alert.Urgency.ToCore(),
					Response = alert.Response.ToCore(),
					ExternalId = alert.Id,
				};

				foreach (UgcZone zone in alert.Zones)
				{
					if (alertZones.TryGetValue(zone.ToString(), out Core.AlertZone? alertZone))
					{
						currentAlert.AddZone(alertZone);
					}
				}

				currentAlerts.Add(currentAlert);
			}
		}

		return currentAlerts;
	}
}
