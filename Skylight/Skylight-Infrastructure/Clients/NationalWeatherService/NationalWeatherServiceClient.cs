using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;
using Skylight.Infrastructure.Configuration;
using System.Text.Json;

namespace Skylight.Infrastructure.Clients.NationalWeatherService;

public class NationalWeatherServiceClient(IOptions<NationalWeatherServiceClientOptions> options)
    : BaseClient, INationalWeatherServiceClient
{
    internal IFlurlRequest BaseRequest => options.Value.BaseUrl
        .WithHeader(HeaderNames.UserAgent, options.Value.UserAgent);

    public async Task<GetActiveAlertsResponse> GetActiveAlerts(GetActiveAlertsRequest request, CancellationToken cancellationToken)
    {
        string rawResponse = await PrepareGetActiveAlertsRequest(request)
            .GetStringAsync(cancellationToken: cancellationToken);

        return PrepareGetActiveAlertsResponse(rawResponse);
    }

    internal virtual IFlurlRequest PrepareGetActiveAlertsRequest(GetActiveAlertsRequest request)
    {
        return BaseRequest
            .AppendPathSegment("alerts")
            .AppendPathSegment("active")
            .SetQueryParams(new
            {
                status = request.Status?.ToString()!.ToLowerInvariant(),
                message_type = request.MessageType?.ToString()!.ToLowerInvariant(),
                @event = request.EventName,
                code = request.EventCode,
                urgency = request.Urgency?.ToString()!,
                severity = request.Severity?.ToString()!,
                certainty = request.Certainty?.ToString()!,
                limit = request.Limit,
            });
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
                    Onset: x.GetProperty("onset").GetDateTimeOffset(),
                    Expires: x.GetProperty("expires").GetDateTimeOffset(),
                    Ends: x.GetProperty("ends").GetDateTimeOffset(),
                    Status: Enum.Parse<AlertStatus>(x.GetProperty("status").GetString()!),
                    MessageType: Enum.Parse<AlertMessageType>(x.GetProperty("messageType").GetString()!),
                    Severity: Enum.Parse<AlertSeverity>(x.GetProperty("severity").GetString()!),
                    Category: Enum.Parse<AlertCategory>(x.GetProperty("category").GetString()!),
                    Urgency: Enum.Parse<AlertUrgency>(x.GetProperty("urgency").GetString()!),
                    Certainty: Enum.Parse<AlertCertainty>(x.GetProperty("certainty").GetString()!),
                    Event: x.GetProperty("event").GetString()!,
                    SenderName: x.GetProperty("senderName").GetString()!,
                    Headline: x.GetProperty("headline").GetString()!,
                    Description: x.GetProperty("description").GetString()!,
                    Instruction: x.GetProperty("instruction").GetString()!,
                    Response: Enum.Parse<AlertResponse>(x.GetProperty("response").GetString()!))).ToList()));
    }
}
