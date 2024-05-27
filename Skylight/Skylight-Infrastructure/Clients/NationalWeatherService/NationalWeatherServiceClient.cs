using FluentValidation;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Skylight.Domain.Extensions;
using Skylight.Infrastructure.Clients.NationalWeatherService.Actions;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using System.Text.Json;

namespace Skylight.Infrastructure.Clients.NationalWeatherService;

public class NationalWeatherServiceClient(
	ILogger<NationalWeatherServiceClient> logger,
	IOptions<NationalWeatherServiceClientOptions> options,
	IValidator<GetActiveAlertsRequest> getActiveAlertsValidator)
    : BaseClient, INationalWeatherServiceClient
{
    internal IFlurlRequest BaseRequest => options.Value.BaseUrl
        .WithHeader(HeaderNames.UserAgent, options.Value.UserAgent);

    public async Task<GetActiveAlertsResponse> GetActiveAlertsAsync(GetActiveAlertsRequest request, CancellationToken cancellationToken)
    {
		getActiveAlertsValidator.ValidateAndThrow(request);

		IFlurlRequest clientRequest = PrepareGetActiveAlertsRequest(request);

		logger.LogInformation("Sending HTTP request to {url}.", clientRequest.Url);
		
		string clientResponse = await clientRequest.GetStringAsync(cancellationToken: cancellationToken);

        return PrepareGetActiveAlertsResponse(clientResponse);
    }

    internal virtual IFlurlRequest PrepareGetActiveAlertsRequest(GetActiveAlertsRequest request)
    {
        return BaseRequest
            .AppendPathSegment("alerts")
            .AppendPathSegment("active")
            .SetQueryParams(new
            {
                status = ToLower(request.Statuses),
                message_type = ToLower(request.MessageTypes),
                @event = request.EventNames,
                code = request.EventCodes,
                urgency = request.Urgencies,
                severity = request.Severities,
                certainty = request.Certainties,
                limit = request.Limit,
            })
			.AppendQueryParam(request.Location?.QueryName, request.Location?.QueryValue);
    }

    internal virtual GetActiveAlertsResponse PrepareGetActiveAlertsResponse(string response)
    {
        using JsonDocument json = JsonDocument.Parse(response);
        JsonElement root = json.RootElement;
        IReadOnlyDictionary<string, JsonElement> properties = GetGeoJsonProperties(root);

		return new GetActiveAlertsResponse(
            AlertCollection: new(
                Title: root.GetProperty("title").GetString()!,
                Updated: root.GetProperty("updated").GetDateTimeOffset(),
                Alerts: properties.Values.Select(x => new Alert(
                    Id: x.GetProperty("id").GetString()!,
                    AreaDescription: x.GetProperty("areaDesc").GetString()!,
                    ZoneIds: x.GetProperty("geocode").GetProperty("UGC").EnumerateArray().Select(x => x.GetString()!).ToArray(),
                    Sent: x.GetProperty("sent").GetDateTimeOffset(),
                    Effective: x.GetProperty("effective").GetDateTimeOffset(),
                    Onset: x.GetOptionalProperty("onset")?.GetDateTimeOffset(),
                    Expires: x.GetProperty("expires").GetDateTimeOffset(),
                    Ends: x.GetOptionalProperty("ends")?.GetDateTimeOffset(),
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
                    Response: Enum.Parse<AlertResponse>(x.GetProperty("response").GetString()!)))
				.OrderByDescending(x => x.Effective)
				.ToList()));
    }
}
