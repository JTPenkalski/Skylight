using Asp.Versioning;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Skylight.Application.UseCases.StormTrackers;
using Skylight.Domain.Entities;

namespace Skylight.Controllers;

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
    /// Gets all <see cref="StormTracker"/>s with the specified name.
    /// </summary>
    /// <returns>A <see cref="GetStormTrackersByNameResponse"/> data object.</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    [Route(nameof(GetStormTrackersByName))]
    public virtual async Task<ActionResult<GetStormTrackersByNameResponse>> GetStormTrackersByName(GetStormTrackersByNameQuery request, CancellationToken cancellationToken)
    {
        Result<GetStormTrackersByNameResponse> result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }
}
