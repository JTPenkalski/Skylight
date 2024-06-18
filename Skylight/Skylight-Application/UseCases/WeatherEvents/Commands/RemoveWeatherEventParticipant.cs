using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record RemoveWeatherEventParticipantCommand(
    Guid WeatherEventId,
    Guid StormTrackerId)
    : ICommand<RemoveWeatherEventParticipantResponse>;

public sealed record RemoveWeatherEventParticipantResponse(bool Removed)
	: IResponse;

public sealed class WeatherEventParticipantNotFoundError()
	: Error($"The {nameof(WeatherEventParticipant)} was not found and could not be removed.");

public class RemoveWeatherEventParticipantCommandHandler(ISkylightContext dbContext)
    : ICommandHandler<RemoveWeatherEventParticipantCommand, RemoveWeatherEventParticipantResponse>
{
    public async Task<Result<RemoveWeatherEventParticipantResponse>> Handle(RemoveWeatherEventParticipantCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);

		bool removed = weatherEvent.RemoveParticipantByStormTrackerId(request.StormTrackerId);

        await dbContext.CommitAsync(cancellationToken);

		var response = new RemoveWeatherEventParticipantResponse(removed);

		return Result
			.FailIf(!removed, new WeatherEventParticipantNotFoundError())
			.ToResult(response);
	}
}
