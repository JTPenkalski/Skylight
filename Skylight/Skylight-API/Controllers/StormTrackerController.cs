using Asp.Versioning;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Skylight.Application.UseCases.StormTrackers;
using Skylight.Domain.Entities;

namespace Skylight.Controllers
{
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
        /// Gets a <see cref="StormTracker"/> by their name.
        /// </summary>
        /// <param name="request">Data to find the entity.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route(nameof(GetStormTrackerByName))]
        public virtual async Task<ActionResult<GetStormTrackerByNameResponse>> GetStormTrackerByName(GetStormTrackerByNameQuery request, CancellationToken cancellationToken)
        {
            Result<GetStormTrackerByNameResponse> result = await mediator.Send(request, cancellationToken);

            return result.ToActionResult();
        }
    }
}
