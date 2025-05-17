using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Services;
using Skylight.Domain.Common.Extensions;
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

		Dictionary<string, Core.AlertType> alertTypes = await GetAlertTypesAsync(clientResponse.AlertCollection.Alerts, cancellationToken);
		Dictionary<string, Core.AlertSender> alertSenders = await GetAlertSendersAsync(clientResponse.AlertCollection.Alerts, cancellationToken);
		Dictionary<string, Core.Zone> zones = await GetZonesAsync(clientResponse.AlertCollection.Alerts, cancellationToken);

		return MapCurrentAlerts(clientResponse, alertTypes, alertSenders, zones);
	}

	internal async Task<Dictionary<string, Core.AlertType>> GetAlertTypesAsync(IEnumerable<Alert> alerts, CancellationToken cancellationToken)
	{
		HashSet<string> typeCodes = [.. alerts.Select(x => x.TypeCode)];

		var typesByEventCode = dbContext.AlertTypes
			.Where(x => x.EventCode != null && typeCodes.Contains(x.EventCode))
			.Select(x => new { Key = x.EventCode!, Value = x });
		var typesByProductCode = dbContext.AlertTypes
			.Where(x => typeCodes.Contains(x.ProductCode))
			.Select(x => new { Key = x.ProductCode, Value = x });

		Dictionary<string, Core.AlertType> alertTypes = await typesByEventCode
			.Union(typesByProductCode)
			.ToDictionaryAsync(x => x.Key, x => x.Value, cancellationToken);

		return alertTypes;
	}

	internal async Task<Dictionary<string, Core.AlertSender>> GetAlertSendersAsync(IEnumerable<Alert> alerts, CancellationToken cancellationToken)
	{
		HashSet<string> senderNames = [.. alerts.Select(x => x.AwipsId.OfficeIdentifier)];
		Dictionary<string, Core.AlertSender> senders = await dbContext.AlertSenders
			.Where(x => senderNames.Contains(x.Code))
			.ToDictionaryAsync(x => x.Code, cancellationToken);

		return senders;
	}

	internal async Task<Dictionary<string, Core.Zone>> GetZonesAsync(IEnumerable<Alert> alerts, CancellationToken cancellationToken)
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
			if (alertTypes.TryGetValue(alert.TypeCode, out Core.AlertType? alertType)
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

				currentAlert.AddParameter(Core.AlertParameterKey.EventMotionDescription, alert.EventMotionDescription?.ToString());
				currentAlert.AddParameter(Core.AlertParameterKey.EventSpeed, alert.EventMotionDescription?.Speed.ToString());
				currentAlert.AddParameter(Core.AlertParameterKey.EventDirection, alert.EventMotionDescription?.Degrees.ToString());
				currentAlert.AddParameter(Core.AlertParameterKey.EventPosition, alert.EventMotionDescription?.LatLon.ToString());
				currentAlert.AddParameter(Core.AlertParameterKey.EventEndingTime, alert.EventEndingTime.ToString());
				currentAlert.AddParameter(Core.AlertParameterKey.MaxHailSize, alert.MaxHailSize);
				currentAlert.AddParameter(Core.AlertParameterKey.HailThreat, alert.HailThreat);
				currentAlert.AddParameter(Core.AlertParameterKey.MaxWindGust, alert.MaxWindGust);
				currentAlert.AddParameter(Core.AlertParameterKey.WindThreat, alert.WindThreat);
				currentAlert.AddParameter(Core.AlertParameterKey.ThunderstormThreat, alert.ThunderstormThreat?.ToTitleCase());
				currentAlert.AddParameter(Core.AlertParameterKey.ThunderstormDamageThreat, alert.ThunderstormDamageThreat);
				currentAlert.AddParameter(Core.AlertParameterKey.TornadoDetection, alert.TornadoDetection);
				currentAlert.AddParameter(Core.AlertParameterKey.TornadoDamageThreat, alert.TornadoDamageThreat);
				currentAlert.AddParameter(Core.AlertParameterKey.FlashFloodDetection, alert.FlashFloodDetection);
				currentAlert.AddParameter(Core.AlertParameterKey.FlashFloodDamageThreat, alert.FlashFloodDamageThreat);
				currentAlert.AddParameter(Core.AlertParameterKey.SnowSquallDetection, alert.SnowSquallDetection);
				currentAlert.AddParameter(Core.AlertParameterKey.SnowSquallImpact, alert.SnowSquallImpact);
				currentAlert.AddParameter(Core.AlertParameterKey.WaterspoutDetection, alert.WaterspoutDetection);
				currentAlert.AddParameter(Core.AlertParameterKey.ValidTimeEventCode, alert.ValidTimeEventCode?.ToString());
				currentAlert.AddParameter(Core.AlertParameterKey.Action, alert.ValidTimeEventCode?.Action);
				currentAlert.AddParameter(Core.AlertParameterKey.OfficeId, alert.ValidTimeEventCode?.OfficeId);
				currentAlert.AddParameter(Core.AlertParameterKey.Phenomena, alert.ValidTimeEventCode?.Phenomena);
				currentAlert.AddParameter(Core.AlertParameterKey.Significance, alert.ValidTimeEventCode?.Significance);
				currentAlert.AddParameter(Core.AlertParameterKey.EventTrackingNumber, alert.ValidTimeEventCode?.EventTrackingNumber);
				currentAlert.AddParameter(Core.AlertParameterKey.EventBeginningDate, alert.ValidTimeEventCode?.EventBeginningDate);
				currentAlert.AddParameter(Core.AlertParameterKey.EventEndingDate, alert.ValidTimeEventCode?.EventEndingDate);

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
