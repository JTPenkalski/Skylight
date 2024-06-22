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
    int? AffectedPeople,
	IEnumerable<string> Tags)
    : IResponse;

public class GetWeatherEventByIdQueryHandler(ISkylightContext dbContext)
    : IQueryHandler<GetWeatherEventByIdQuery, GetWeatherEventByIdResponse>
{
    public async Task<Result<GetWeatherEventByIdResponse>> Handle(GetWeatherEventByIdQuery request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.Id, cancellationToken);
        IEnumerable<string> weatherEventTags = weatherEvent.Tags
			.Where(x => x.EffectiveDate.HasValue)
			.Select(x => x.Tag.Name).ToList();

        var response = new GetWeatherEventByIdResponse(
            Name: weatherEvent.Name,
            Description: weatherEvent.Description,
            StartDate: weatherEvent.StartDate,
            EndDate: weatherEvent.EndDate,
            DamageCost: weatherEvent.DamageCost,
            AffectedPeople: weatherEvent.AffectedPeople,
			Tags: weatherEventTags);
        
        return Result.Ok(response);
    }
}
