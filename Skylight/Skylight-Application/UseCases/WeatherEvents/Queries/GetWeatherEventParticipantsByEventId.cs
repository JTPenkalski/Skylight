using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record GetWeatherEventParticipantsByEventIdQuery(Guid WeatherEventId)
	: IQuery<GetWeatherEventParticipantsByEventIdResponse>;

public sealed record GetWeatherEventParticipantsByEventIdResponse : IResponse
{
	public required IEnumerable<WeatherEventParticipant> WeatherEventParticipants { get; init; }

	public sealed record WeatherEventParticipant(
		string FirstName,
		string LastName,
		ParticipationMethod ParticipationMethod,
		DateTimeOffset ParticipationDate);
}

public class GetWeatherEventParticipantsByEventIdQueryHandler(ISkylightContext dbContext) : IQueryHandler<GetWeatherEventParticipantsByEventIdQuery, GetWeatherEventParticipantsByEventIdResponse>
{
	public async Task<Result<GetWeatherEventParticipantsByEventIdResponse>> Handle(GetWeatherEventParticipantsByEventIdQuery request, CancellationToken cancellationToken)
	{
		var participants = new List<GetWeatherEventParticipantsByEventIdResponse.WeatherEventParticipant>();
		IEnumerable<WeatherEventParticipant> weatherEventParticipants = (await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken))?.Participants ?? [];

		foreach (WeatherEventParticipant weatherEventParticipant in weatherEventParticipants)
		{
			var participant = new GetWeatherEventParticipantsByEventIdResponse.WeatherEventParticipant(
				weatherEventParticipant.Tracker.FirstName,
				weatherEventParticipant.Tracker.LastName,
				weatherEventParticipant.ParticipationMethod,
				weatherEventParticipant.Created);

			participants.Add(participant);
		}

		var response = new GetWeatherEventParticipantsByEventIdResponse
		{
			WeatherEventParticipants = participants
		};

		return Result.Ok(response);
	}
}
