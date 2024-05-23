using FluentResults;
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
    int? AffectedPeople);

public class GetWeatherEventByIdQueryHandler(ISkylightContext context)
    : IQueryHandler<GetWeatherEventByIdQuery, GetWeatherEventByIdResponse>
{
    public async Task<Result<GetWeatherEventByIdResponse>> Handle(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
    {
        WeatherEvent? weatherEvent = await context.WeatherEvents
            .FindAsync([request.Id], cancellationToken);

        if (weatherEvent is null)
        {
            return Result.Fail($"{nameof(WeatherEvent)} was not found.");
        }

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
