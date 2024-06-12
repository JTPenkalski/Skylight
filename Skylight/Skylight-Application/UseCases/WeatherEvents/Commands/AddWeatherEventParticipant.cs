using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record AddWeatherEventParticipantCommand(
    Guid WeatherEventId,
    Guid StormTrackerId,
    ParticipationMethod ParticipationMethod)
    : ICommand<AddWeatherEventParticipantResponse>;

public sealed record AddWeatherEventParticipantResponse(bool Added)
	: IResponse;

public sealed class WeatherEventParticipantAlreadyAddedError()
	: Error($"The {nameof(WeatherEventParticipant)} was already added to the {nameof(WeatherEvent)} and was not added again.");

public class AddWeatherEventParticipantCommandHandler(ISkylightContext dbContext)
    : ICommandHandler<AddWeatherEventParticipantCommand, AddWeatherEventParticipantResponse>
{
    public async Task<Result<AddWeatherEventParticipantResponse>> Handle(AddWeatherEventParticipantCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
        StormTracker stormTracker = await dbContext.FindAsync<StormTracker>(request.StormTrackerId, cancellationToken);

        var participant = new WeatherEventParticipant
        {
            Event = weatherEvent,
            Tracker = stormTracker,
            ParticipationMethod = request.ParticipationMethod
        };

        bool added = weatherEvent.AddParticipant(participant);

        await dbContext.CommitAsync(cancellationToken);

		var response = new AddWeatherEventParticipantResponse(added);

		return Result
			.FailIf(!added, new WeatherEventParticipantAlreadyAddedError())
			.ToResult(response);
	}
}
