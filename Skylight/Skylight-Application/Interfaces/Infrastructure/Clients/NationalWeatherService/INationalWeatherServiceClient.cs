namespace Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;

/// <summary>
/// Manages data access from the National Weather Service API.
/// </summary>
public interface INationalWeatherServiceClient
{
    Task<GetActiveAlertsResponse> GetActiveAlerts(GetActiveAlertsRequest request, CancellationToken cancellationToken);
}
