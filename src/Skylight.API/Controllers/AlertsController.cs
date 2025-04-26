using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Skylight.API.Extensions;
using Skylight.Application.Features.Alerts.AddCurrentAlerts;
using Skylight.Application.Features.Alerts.GetAlertSenders;
using Skylight.Application.Features.Alerts.GetAlertTypes;
using Skylight.Application.Features.Alerts.GetCurrentAlertsByType;

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

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<GetCurrentAlertsByTypeResponse>> GetCurrentAlertsByType(GetCurrentAlertsByTypeQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<GetAlertSendersResponse>> GetAlertSenders(GetAlertSendersQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<GetAlertTypesResponse>> GetAlertTypes(GetAlertTypesQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}
}
