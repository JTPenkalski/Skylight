using Asp.Versioning;
using AutoMapper;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Skylight.Application.Features.WeatherEvents;
using Skylight.Web.Models;
using Core = Skylight.Domain.Entities;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WeatherEvent"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(SkylightApiVersion.VERSION)]
    public class WeatherEventController(
        IMapper mapper,
        IMediator mediator)
        : BaseController<Core.WeatherEvent, WeatherEvent>
    {
        /// <summary>
        /// Creates a new <see cref="WeatherEvent"/>.
        /// </summary>
        /// <param name="request">Data to create the entity.</param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public virtual async Task<ActionResult<WeatherEvent>> CreateWeatherEvent(CreateWeatherEventCommand request, CancellationToken cancellationToken)
        {
            Result<Core.WeatherEvent> result = await mediator.Send(request, cancellationToken);

            return result.Map(mapper.Map<Core.WeatherEvent, WeatherEvent>).ToActionResult();
        }
    }
}
