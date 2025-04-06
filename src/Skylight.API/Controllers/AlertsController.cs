using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Skylight.Application.Features.Alerts.AddCurrentAlerts;

namespace Skylight.API.Controllers;

[ApiController]
[ApiVersion(SkylightApiVersion.Current)]
public class AlertsController(IMediator mediator)
	: BaseController
{
	[HttpPost]
    public async Task<ActionResult<AddCurrentAlertsResponse>> AddCurrentAlerts(AddCurrentAlertsCommand request, CancellationToken cancellationToken)
    {
		var result = await mediator.Send(request, cancellationToken);

		return result.IsSuccess
			? Ok(result.Value)
			: BadRequest(result.Errors);
    }
}
