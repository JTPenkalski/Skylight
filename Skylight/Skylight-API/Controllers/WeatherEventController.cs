﻿using Asp.Versioning;
using FluentResults;
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
    /// Creates a new <see cref="WeatherEvent"/>.
    /// </summary>
    [HttpPost]
	[AdminAuthorize]
    [Route(nameof(CreateWeatherEvent))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateWeatherEventResponse>> CreateWeatherEvent(CreateWeatherEventCommand request, CancellationToken cancellationToken)
    {
        Result<CreateWeatherEventResponse> result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

    /// <summary>
    /// Adds a <see cref="StormTracker"/> to a <see cref="WeatherEvent"/>.
    /// </summary>
    [HttpPost]
    [Route(nameof(AddWeatherEventParticipant))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddWeatherEventParticipant(AddWeatherEventParticipantCommand request, CancellationToken cancellationToken)
    {
        Result result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

    /// <summary>
    /// Adds all new <see cref="WeatherAlert"/>s to a <see cref="WeatherEvent"/>.
    /// </summary>
    [HttpPost]
    [Route(nameof(FetchWeatherAlerts))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FetchWeatherAlertsResponse>> FetchWeatherAlerts(FetchWeatherAlertsCommand request, CancellationToken cancellationToken)
    {
        Result<FetchWeatherAlertsResponse> result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

	/// <summary>
	/// Gets a <see cref="WeatherEvent"/> by its ID.
	/// </summary>
	[HttpPost]
    [Route(nameof(GetWeatherEventById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetWeatherEventByIdResponse>> GetWeatherEventById(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
    {
        Result<GetWeatherEventByIdResponse> result = await mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

	/// <summary>
	/// Gets all <see cref="WeatherEventAlert"/>s for a <see cref="WeatherEvent"/> by its ID.
	/// </summary>
	[HttpPost]
	[Route(nameof(GetWeatherAlertsByEventId))]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetWeatherAlertsByEventIdResponse>> GetWeatherAlertsByEventId(GetWeatherAlertsByEventIdQuery request, CancellationToken cancellationToken)
	{
		Result<GetWeatherAlertsByEventIdResponse> result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}
}
