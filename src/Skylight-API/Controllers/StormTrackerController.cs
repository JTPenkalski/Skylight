using Asp.Versioning;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Skylight.API.Controllers;
using Skylight.Application.UseCases.StormTrackers;
using Skylight.Domain.Entities;

namespace Skylight.API.Controllers;

/// <summary>
/// Web API Controller for manipulating <see cref="StromTracker"/> models.
/// </summary>
[ApiController]
[ApiVersion(SkylightApiVersion.VERSION)]
public class StormTrackerController(
    IMediator mediator)
    : BaseController
{
	/// <summary>
	/// Gets all <see cref="StormTracker"/> with the specified email.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetStormTrackerByEmailResponse>> GetStormTrackerByEmail(GetStormTrackerByEmailQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Gets all <see cref="StormTracker"/>s with the specified name.
	/// </summary>
	[HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetStormTrackersByNameResponse>> GetStormTrackersByName(GetStormTrackersByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }
}
