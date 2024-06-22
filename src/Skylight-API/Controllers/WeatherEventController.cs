using Asp.Versioning;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Skylight.Application.UseCases.WeatherEvents;
using Skylight.Domain.Entities;
using Skylight.Infrastructure.Identity.Attributes;

namespace Skylight.Controllers;

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
	/// Adds a <see cref="StormTracker"/> to a <see cref="WeatherEvent"/>.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<AddWeatherEventParticipantResponse>> AddWeatherEventParticipant(AddWeatherEventParticipantCommand request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Adds a <see cref="Tag"/> to a <see cref="WeatherEvent"/>.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<AddWeatherEventTagResponse>> AddWeatherEventTag(AddWeatherEventTagCommand request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Creates a new <see cref="WeatherEvent"/>.
	/// </summary>
	[HttpPost]
	[AdminAuthorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateWeatherEventResponse>> CreateWeatherEvent(CreateWeatherEventCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

    /// <summary>
    /// Adds all new <see cref="WeatherAlert"/>s to a <see cref="WeatherEvent"/>.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FetchWeatherAlertsResponse>> FetchWeatherAlerts(FetchWeatherAlertsCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

	/// <summary>
	/// Removes a <see cref="StormTracker"/> from a <see cref="WeatherEvent"/>.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<RemoveWeatherEventParticipantResponse>> RemoveWeatherEventParticipant(RemoveWeatherEventParticipantCommand request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Gets a <see cref="WeatherEvent"/> by its ID.
	/// </summary>
	[HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetWeatherEventByIdResponse>> GetWeatherEventById(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

	/// <summary>
	/// Gets all <see cref="WeatherEventAlert"/>s for a <see cref="WeatherEvent"/> by its ID.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetWeatherAlertsByEventIdResponse>> GetWeatherAlertsByEventId(GetWeatherAlertsByEventIdQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Gets all <see cref="WeatherEventParticipant"/>s for a <see cref="WeatherEvent"/> by its ID.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetWeatherEventParticipantsByEventIdResponse>> GetWeatherEventParticipantsByEventId(GetWeatherEventParticipantsByEventIdQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Gets the status of a <see cref="WeatherEventParticipant"/> for a <see cref="WeatherEvent"/>.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetWeatherEventParticipantStatusResponse>> GetWeatherEventParticipantsStatus(GetWeatherEventParticipantStatusQuery request, CancellationToken cancellationToken)
	{
		var result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}
}
