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
	public const int RequestChunkSize = 500;

	public async Task<List<Core.Alert>> GetActiveAlertsAsync(CancellationToken cancellationToken)
	{
		var clientRequest = new GetActiveAlertsRequest(
			Statuses: [AlertStatus.Actual],
			MessageTypes: [AlertMessageType.Alert]);

		GetActiveAlertsResponse clientResponse = await nwsClient.GetActiveAlertsAsync(clientRequest, cancellationToken);

		List<Alert> alerts = [.. clientResponse.AlertCollection.Alerts];
		Dictionary<string, Core.AlertType> alertTypes = await GetAlertTypesAsync(alerts, cancellationToken);
		Dictionary<string, Core.AlertSender> alertSenders = await GetAlertSendersAsync(alerts, cancellationToken);
		Dictionary<string, Core.Zone> zones = await GetZonesAsync(alerts, cancellationToken);

		return MapCurrentAlerts(clientResponse, alertTypes, alertSenders, zones);
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

	internal async Task<Dictionary<string, Core.Zone>> GetZonesAsync(List<Alert> alerts, CancellationToken cancellationToken)
	{
		HashSet<string> allZones = [.. alerts.SelectMany(x => x.Zones.Select(x => x.ToString()))];

		Dictionary<string, Core.Zone> knownZones = await dbContext.Zones
			.Where(x => allZones.Contains(x.Code))
			.ToDictionaryAsync(x => x.Code, cancellationToken);

		IEnumerable<string[]> unknownZoneChunks = allZones
			.Except(knownZones.Keys)
			.Chunk(RequestChunkSize);

		foreach (string[] unknownZones in unknownZoneChunks)
		{
			var clientRequest = new GetZonesRequest(
				ZoneIds: unknownZones,
				ZoneTypes: [ZoneType.Public, ZoneType.County]);

			GetZonesResponse response = await nwsClient.GetZonesAsync(clientRequest, cancellationToken);

			foreach (Zone zone in response.Zones)
			{
				var newZone = new Core.Zone
				{
					Code = zone.Id.ToString(),
					Name = zone.FullName,
				};

				knownZones.Add(newZone.Code, newZone);
			}
		}

		return knownZones;
	}

	internal static List<Core.Alert> MapCurrentAlerts(
		GetActiveAlertsResponse clientResponse,
		Dictionary<string, Core.AlertType> alertTypes,
		Dictionary<string, Core.AlertSender> alertSenders,
		Dictionary<string, Core.Zone> zones)
	{
		var currentAlerts = new List<Core.Alert>();

		foreach (Alert alert in clientResponse.AlertCollection.Alerts)
		{
			if (alertTypes.TryGetValue(alert.AwipsId.ProductCategory, out Core.AlertType? alertType)
				&& alertSenders.TryGetValue(alert.AwipsId.OfficeIdentifier, out Core.AlertSender? alertSender))
			{
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

				currentAlert.AddParameter(Core.AlertParameterKeys.EventMotionDescription, alert.EventMotionDescription?.ToString());
				currentAlert.AddParameter(Core.AlertParameterKeys.Speed, alert.EventMotionDescription?.Speed.ToString());
				currentAlert.AddParameter(Core.AlertParameterKeys.Direction, alert.EventMotionDescription?.Degrees.ToString());
				currentAlert.AddParameter(Core.AlertParameterKeys.Position, alert.EventMotionDescription?.LatLon.ToString());
				currentAlert.AddParameter(Core.AlertParameterKeys.EventEndingTime, alert.EventEndingTime.ToString());
				currentAlert.AddParameter(Core.AlertParameterKeys.MaxHailSize, alert.MaxHailSize);
				currentAlert.AddParameter(Core.AlertParameterKeys.HailThreat, alert.HailThreat);
				currentAlert.AddParameter(Core.AlertParameterKeys.MaxWindGust, alert.MaxWindGust);
				currentAlert.AddParameter(Core.AlertParameterKeys.WindThreat, alert.WindThreat);
				currentAlert.AddParameter(Core.AlertParameterKeys.ThunderstormDamageThreat, alert.ThunderstormDamageThreat);
				currentAlert.AddParameter(Core.AlertParameterKeys.TornadoDetection, alert.TornadoDetection);
				currentAlert.AddParameter(Core.AlertParameterKeys.TornadoDamageThreat, alert.TornadoDamageThreat);
				currentAlert.AddParameter(Core.AlertParameterKeys.FlashFloodDetection, alert.FlashFloodDetection);
				currentAlert.AddParameter(Core.AlertParameterKeys.FlashFloodDamageThreat, alert.FlashFloodDamageThreat);
				currentAlert.AddParameter(Core.AlertParameterKeys.SnowSquallDetection, alert.SnowSquallDetection);
				currentAlert.AddParameter(Core.AlertParameterKeys.SnowSquallImpact, alert.SnowSquallImpact);
				currentAlert.AddParameter(Core.AlertParameterKeys.WaterspoutDetection, alert.WaterspoutDetection);

				if (currentAlert.Description.Contains("THIS IS A PARTICULARLY DANGEROUS SITUATION"))
				{
					currentAlert.AddParameter(Core.AlertParameterKeys.TypeModifier, Core.AlertParameterValues.ParticularlyDangerousSituation);
				}

				foreach (UgcZone ugcZone in alert.Zones)
				{
					if (zones.TryGetValue(ugcZone.ToString(), out Core.Zone? zone))
					{
						currentAlert.AddZone(zone);
					}
				}

				currentAlerts.Add(currentAlert);
			}
		}

		return currentAlerts;
	}
}
