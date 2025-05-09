using FluentValidation;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Skylight.Application.Serialization;
using Skylight.Domain.Common.Extensions;
using Skylight.Infrastructure.Clients.NationalWeatherService.Endpoints;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using System.Text.Json;

namespace Skylight.Infrastructure.Clients.NationalWeatherService;

public class NationalWeatherServiceClient(
	ILogger<NationalWeatherServiceClient> logger,
	IOptions<NationalWeatherServiceOptions> options,
	IValidator<GetActiveAlertsRequest> getActiveAlertsValidator,
	IValidator<GetZonesRequest> getZonesValidator,
	IGeoJsonService geoJsonService)
	: BaseClient(logger)
	, INationalWeatherServiceClient
{
	internal override IFlurlRequest BaseRequest => options.Value.BaseUrl
		.WithTimeout(1000)
		.WithHeader(HeaderNames.UserAgent, options.Value.UserAgent);

	#region Active Alerts

	public async Task<GetActiveAlertsResponse> GetActiveAlertsAsync(GetActiveAlertsRequest request, CancellationToken cancellationToken) =>
		await ExecuteRequestAsync(
			request,
			PrepareGetActiveAlertsRequest,
			PrepareGetActiveAlertsResponse,
			cancellationToken,
			getActiveAlertsValidator);

	internal virtual IFlurlRequest PrepareGetActiveAlertsRequest(GetActiveAlertsRequest request)
	{
		return BaseRequest
			.AppendPathSegment("alerts")
			.AppendPathSegment("active")
			.SetQueryParams(new
			{
				status = request.Statuses.ToLower().ToCsv(),
				message_type = request.MessageTypes.ToLower().ToCsv(),
				@event = request.EventNames.ToCsv(),
				code = request.EventCodes.ToCsv(),
				urgency = request.Urgencies.ToCsv(),
				severity = request.Severities.ToCsv(),
				certainty = request.Certainties.ToCsv(),
				limit = request.Limit,
			})
			.AppendQueryParam(request.Location?.QueryName, request.Location?.QueryValue);
	}

	internal virtual GetActiveAlertsResponse PrepareGetActiveAlertsResponse(string response)
	{
		using JsonDocument json = JsonDocument.Parse(response);
		JsonElement root = json.RootElement;
		IReadOnlyDictionary<string, JsonElement> properties = geoJsonService.GetGeoJsonProperties(root);

		return new GetActiveAlertsResponse(
			AlertCollection: new(
				Title: root.GetProperty("title").GetString()!,
				Updated: root.GetProperty("updated").GetDateTimeOffset(),
				Alerts: properties.Values
					.Select(x => new Alert(
						Id: x.GetProperty("id").GetString()!,
						AreaDescription: x.GetProperty("areaDesc").GetString()!,
						Zones: [.. x.GetProperty("geocode").GetProperty("UGC").EnumerateArray()
							.Select(x => UgcZone.Parse(x.GetString()!))],
						Sent: x.GetProperty("sent").GetDateTimeOffset().ToUniversalTime(),
						Effective: x.GetProperty("effective").GetDateTimeOffset().ToUniversalTime(),
						Onset: x.GetOptionalProperty("onset")?.GetDateTimeOffset().ToUniversalTime(),
						Expires: x.GetProperty("expires").GetDateTimeOffset().ToUniversalTime(),
						Ends: x.GetOptionalProperty("ends")?.GetDateTimeOffset().ToUniversalTime(),
						Status: Enum.Parse<AlertStatus>(x.GetProperty("status").GetString()!),
						MessageType: Enum.Parse<AlertMessageType>(x.GetProperty("messageType").GetString()!),
						Severity: Enum.Parse<AlertSeverity>(x.GetProperty("severity").GetString()!),
						Category: Enum.Parse<AlertCategory>(x.GetProperty("category").GetString()!),
						Urgency: Enum.Parse<AlertUrgency>(x.GetProperty("urgency").GetString()!),
						Certainty: Enum.Parse<AlertCertainty>(x.GetProperty("certainty").GetString()!),
						Event: x.GetProperty("event").GetString()!,
						SenderName: x.GetProperty("senderName").GetString()!,
						Headline: x.GetOptionalProperty("headline")?.GetString()!,
						Description: x.GetProperty("description").GetString()!,
						Instruction: x.GetOptionalProperty("instruction")?.GetString()!,
						Response: Enum.Parse<AlertResponse>(x.GetProperty("response").GetString()!),
						AwipsId: AwipsIdentifier.Parse(x.GetProperty("parameters").GetProperty("AWIPSidentifier").EnumerateArray().Single().GetString()!),
						EventMotionDescription: EventMotionDescription.Parse(x.GetProperty("parameters").GetOptionalProperty("eventMotionDescription")?.EnumerateArray().Single().GetString()),
						WindThreat: x.GetProperty("parameters").GetOptionalProperty("windThreat")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						MaxWindGust: x.GetProperty("parameters").GetOptionalProperty("maxWindGust")?.EnumerateArray().Single().GetString(),
						HailThreat: x.GetProperty("parameters").GetOptionalProperty("hailThreat")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						MaxHailSize: x.GetProperty("parameters").GetOptionalProperty("maxHailSize")?.EnumerateArray().Single().GetString(),
						ThunderstormDamageThreat: x.GetProperty("parameters").GetOptionalProperty("thunderstormDamageThreat")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						TornadoDetection: x.GetProperty("parameters").GetOptionalProperty("tornadoDetection")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						TornadoDamageThreat: x.GetProperty("parameters").GetOptionalProperty("tornadoDamageThreat")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						FlashFloodDetection: x.GetProperty("parameters").GetOptionalProperty("flashFloodDetection")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						FlashFloodDamageThreat: x.GetProperty("parameters").GetOptionalProperty("flashFloodDamageThreat")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						SnowSquallDetection: x.GetProperty("parameters").GetOptionalProperty("snowSquallDetection")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						SnowSquallImpact: x.GetProperty("parameters").GetOptionalProperty("snowSquallImpact")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						WaterspoutDetection: x.GetProperty("parameters").GetOptionalProperty("waterspoutDetection")?.EnumerateArray().Single().GetString()?.ToLower().ToTitleCase(),
						ValidTimeEventCode: ValidTimeEventCode.Parse(x.GetProperty("parameters").GetOptionalProperty("VTEC")?.EnumerateArray().Single().GetString()),
						EventEndingTime: x.GetOptionalProperty("eventEndingTime")?.GetDateTimeOffset().ToUniversalTime()))
					.OrderByDescending(x => x.Effective)
					.ToList()));
	}

	#endregion

	#region Zones

	public async Task<GetZonesResponse> GetZonesAsync(GetZonesRequest request, CancellationToken cancellationToken) =>
		await ExecuteRequestAsync(
			request,
			PrepareGetZonesRequest,
			PrepareGetZonesResponse,
			cancellationToken,
			getZonesValidator);

	internal virtual IFlurlRequest PrepareGetZonesRequest(GetZonesRequest request)
	{
		return BaseRequest
			.AppendPathSegment("zones")
			.SetQueryParams(new
			{
				id = request.ZoneIds.ToCsv(),
				type = request.ZoneTypes.ToLower().ToCsv(),
				include_geometry = request.IncludeGeometry.ToString().ToLower(),
				limit = request.Limit,
			});
	}

	internal virtual GetZonesResponse PrepareGetZonesResponse(string response)
	{
		using JsonDocument json = JsonDocument.Parse(response);
		JsonElement root = json.RootElement;
		IReadOnlyDictionary<string, JsonElement> properties = geoJsonService.GetGeoJsonProperties(root);

		return new GetZonesResponse(
			Zones: properties.Values
				.Select(x => new Zone(
					Id: UgcZone.Parse(x.GetProperty("id").GetString()!),
					Type: Enum.Parse<ZoneType>(x.GetProperty("type").GetString()!, true),
					Name: x.GetProperty("name").GetString()!,
					State: x.GetProperty("state").GetString()!))
				.ToList());
	}

	#endregion
}
