using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.AddCurrentAlerts;

public class AddCurrentAlertsHandler : ICommandHandler<AddCurrentAlertsCommand, AddCurrentAlertsResponse>
{
	public ValueTask<Result<AddCurrentAlertsResponse>> Handle(AddCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		var response = new AddCurrentAlertsResponse();

		return ValueTask.FromResult(Result.Success(response));
	}
}
