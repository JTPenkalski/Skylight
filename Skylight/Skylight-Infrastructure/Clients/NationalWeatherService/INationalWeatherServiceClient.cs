using Skylight.Infrastructure.Clients.NationalWeatherService.Actions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService;

/// <summary>
/// Manages data access from the National Weather Service API.
/// </summary>
public interface INationalWeatherServiceClient
{
	Task<GetActiveAlertsResponse> GetActiveAlertsAsync(GetActiveAlertsRequest request, CancellationToken cancellationToken);
}
