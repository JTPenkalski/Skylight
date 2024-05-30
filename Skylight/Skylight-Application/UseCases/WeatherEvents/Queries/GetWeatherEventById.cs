﻿using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record GetWeatherEventByIdQuery(Guid Id)
    : IQuery<GetWeatherEventByIdResponse>;

public sealed record GetWeatherEventByIdResponse(
    string Name,
    string Description,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    long? DamageCost,
    int? AffectedPeople)
    : IResponse;

public class GetWeatherEventByIdQueryHandler(ISkylightContext dbContext)
    : IQueryHandler<GetWeatherEventByIdQuery, GetWeatherEventByIdResponse>
{
    public async Task<Result<GetWeatherEventByIdResponse>> Handle(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.Id, cancellationToken);
        
        var response = new GetWeatherEventByIdResponse(
            Name: weatherEvent.Name,
            Description: weatherEvent.Description,
            StartDate: weatherEvent.StartDate,
            EndDate: weatherEvent.EndDate,
            DamageCost: weatherEvent.DamageCost,
            AffectedPeople: weatherEvent.AffectedPeople);
        
        return Result.Ok(response);
    }
}
