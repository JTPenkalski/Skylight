using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;
using Skylight.Domain.Exceptions;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record GetWeatherEventParticipantStatusQuery(
	Guid WeatherEventId,
	Guid StormTrackerId)
	: IQuery<GetWeatherEventParticipantStatusResponse>;

public sealed record GetWeatherEventParticipantStatusResponse(
	ParticipationMethod ParticipationMethod,
	DateTimeOffset ParticipationDate)
	: IResponse;

public class GetWeatherEventParticipantsStatusQueryHandler(ISkylightContext dbContext) : IQueryHandler<GetWeatherEventParticipantStatusQuery, GetWeatherEventParticipantStatusResponse>
{
	public async Task<Result<GetWeatherEventParticipantStatusResponse>> Handle(GetWeatherEventParticipantStatusQuery request, CancellationToken cancellationToken)
	{
		WeatherEventParticipant? weatherEventParticipant = (await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken))?.Participants
			.FirstOrDefault(x => x.Tracker.Id == request.StormTrackerId);

		EntityNotFoundException.ThrowIfNullOrDeleted(weatherEventParticipant, request.StormTrackerId);

		var response = new GetWeatherEventParticipantStatusResponse(weatherEventParticipant.ParticipationMethod, weatherEventParticipant.Created);

		return Result.Ok(response);
	}
}
