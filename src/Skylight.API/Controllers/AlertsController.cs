using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Skylight.API.Extensions;
using Skylight.Application.Features.Alerts.Commands;
using Skylight.Application.Features.Alerts.Queries;

namespace Skylight.API.Controllers;

[ApiController]
[ApiVersion(SkylightApiVersion.Current)]
public class AlertsController(IMediator mediator) : BaseController
{
	[HttpPost]
	public async Task<ActionResult<AddNewAlertsResponse>> AddNewAlerts(AddNewAlertsCommand request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<ExpireCurrentAlertsResponse>> ExpireCurrentAlerts(ExpireCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<GetCurrentAlertCountByTypeResponse>> GetCurrentAlertCountByType(GetCurrentAlertCountByTypeQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<GetCurrentAlertObservationTypesByTypeResponse>> GetCurrentAlertObservationTypesByType(GetCurrentAlertObservationTypesByTypeQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	[HttpPost]
	public async Task<ActionResult<GetCurrentAlertParameterValuesByParameterResponse>> GetCurrentAlertParameterValuesByParameter(GetCurrentAlertParameterValuesByParameterQuery request, CancellationToken cancellationToken)
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
	public async Task<ActionResult<GetHistoricalAlertCountsByTypeResponse>> GetHistoricalAlertCountsByType(GetHistoricalAlertCountsByTypeQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}
}
