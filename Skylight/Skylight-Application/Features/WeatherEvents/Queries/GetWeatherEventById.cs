using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.Features.WeatherEvents;

public sealed record GetWeatherEventByIdQuery(Guid Id)
    : IQuery<WeatherEvent?>;

public class GetWeatherEventByIdQueryHandler(ISkylightContext context)
    : IQueryHandler<GetWeatherEventByIdQuery, WeatherEvent?>
{
    public async Task<Result<WeatherEvent?>> Handle(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
    {
        WeatherEvent? weatherEvent = await context.WeatherEvents
            .FindAsync([request.Id], cancellationToken);

        return Result.FailIf(weatherEvent is null, $"{nameof(WeatherEvent)} was not found.").ToResult(weatherEvent);
    }
}
