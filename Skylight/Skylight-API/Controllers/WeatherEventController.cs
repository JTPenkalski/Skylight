using Asp.Versioning;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Skylight.Application.UseCases.WeatherEvents;
using Skylight.Domain.Entities;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WeatherEvent"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(SkylightApiVersion.VERSION)]
    public class WeatherEventController(
        IMediator mediator)
        : BaseController
    {
        /// <summary>
        /// Creates a new <see cref="WeatherEvent"/>.
        /// </summary>
        /// <param name="request">Data to create the entity.</param>
        /// <returns>A <see cref="CreateWeatherEventResponse"/>.</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route(nameof(CreateWeatherEvent))]
        public virtual async Task<ActionResult<CreateWeatherEventResponse>> CreateWeatherEvent(CreateWeatherEventCommand request, CancellationToken cancellationToken)
        {
            Result<CreateWeatherEventResponse> result = await mediator.Send(request, cancellationToken);

            return result.ToActionResult();
        }

        /// <summary>
        /// Adds a <see cref="StormTracker"/> to a <see cref="WeatherEvent"/>.
        /// </summary>
        /// <param name="request">Data to create the entity.</param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route(nameof(AddWeatherEventParticipant))]
        public virtual async Task<ActionResult> AddWeatherEventParticipant(AddWeatherEventParticipantCommand request, CancellationToken cancellationToken)
        {
            Result result = await mediator.Send(request, cancellationToken);

            return result.ToActionResult();
        }

        /// <summary>
        /// Gets a <see cref="WeatherEvent"/> by its ID.
        /// </summary>
        /// <param name="request">Data to find the entity.</param>
        /// <returns>A <see cref="GetWeatherEventByIdResponse"/>.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route(nameof(GetWeatherEventById))]
        public virtual async Task<ActionResult<GetWeatherEventByIdResponse>> GetWeatherEventById(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
        {
            Result<GetWeatherEventByIdResponse> result = await mediator.Send(request, cancellationToken);

            return result.ToActionResult();
        }
    }
}
