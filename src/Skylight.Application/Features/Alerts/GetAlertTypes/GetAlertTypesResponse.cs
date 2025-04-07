using Skylight.Application.Features.Interfaces;

namespace Skylight.Application.Features.Alerts.GetAlertTypes;

public record GetAlertTypesResponse(IEnumerable<GetAlertTypesResponse.AlertType> Types) : IResponse
{
	public record AlertType(
		string Code,
		string Name,
		string Description,
		string Level);
}
