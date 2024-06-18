using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record GetWeatherEventParticipantStatusQuery(
	Guid WeatherEventId,
	Guid StormTrackerId)
	: IQuery<GetWeatherEventParticipantStatusResponse>;

public sealed record GetWeatherEventParticipantStatusResponse(
	ParticipationMethod ParticipationMethod,
	DateTimeOffset? ParticipationDate = null)
	: IResponse;

public class GetWeatherEventParticipantsStatusQueryHandler(ISkylightContext dbContext) : IQueryHandler<GetWeatherEventParticipantStatusQuery, GetWeatherEventParticipantStatusResponse>
{
	public async Task<Result<GetWeatherEventParticipantStatusResponse>> Handle(GetWeatherEventParticipantStatusQuery request, CancellationToken cancellationToken)
	{
		WeatherEventParticipant? weatherEventParticipant = (await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken))?.Participants
			.FirstOrDefault(x => x.Tracker.Id == request.StormTrackerId);

		var response = weatherEventParticipant is not null
			? new GetWeatherEventParticipantStatusResponse(weatherEventParticipant.ParticipationMethod, weatherEventParticipant.CreatedOn)
			: new GetWeatherEventParticipantStatusResponse(ParticipationMethod.None);

		return Result.Ok(response);
	}
}
