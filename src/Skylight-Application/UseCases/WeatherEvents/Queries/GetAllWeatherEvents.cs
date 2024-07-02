using FluentResults;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record GetAllWeatherEventsQuery()
	: IQuery<GetAllWeatherEventsResponse>;

public sealed record GetAllWeatherEventsResponse : IResponse
{
	public required IEnumerable<WeatherEvent> WeatherEvents { get; init; }

	public sealed record WeatherEvent(
		Guid Id,
		string Name,
		string Description,
		DateTimeOffset StartDate,
		DateTimeOffset? EndDate,
		long? DamageCost,
		int? AffectedPeople,
		IEnumerable<string> Tags);
}

public class GetAllWeatherEventsQueryHandler(ISkylightContext dbContext)
	: IQueryHandler<GetAllWeatherEventsQuery, GetAllWeatherEventsResponse>
{
	public async Task<Result<GetAllWeatherEventsResponse>> Handle(GetAllWeatherEventsQuery request, CancellationToken cancellationToken)
	{
		IEnumerable<WeatherEvent> weatherEvents = await dbContext.WeatherEvents.ToListAsync(cancellationToken);
		var responseWeatherEvents = new List<GetAllWeatherEventsResponse.WeatherEvent>();

		foreach (WeatherEvent weatherEvent in weatherEvents)
		{
			var responseWeatherEvent = new GetAllWeatherEventsResponse.WeatherEvent(
				Id: weatherEvent.Id,
				Name: weatherEvent.Name,
				Description: weatherEvent.Description,
				StartDate: weatherEvent.StartDate,
				EndDate: weatherEvent.EndDate,
				DamageCost: weatherEvent.DamageCost,
				AffectedPeople: weatherEvent.AffectedPeople,
				Tags: weatherEvent.Tags.Select(x => x.Tag.Name).ToList());

			responseWeatherEvents.Add(responseWeatherEvent);
		}

		var response = new GetAllWeatherEventsResponse
		{
			WeatherEvents = responseWeatherEvents
		};

		return Result.Ok(response);
	}
}
