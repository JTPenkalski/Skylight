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
    : ICommand;

public class AddWeatherEventParticipantCommandHandler(ISkylightContext dbContext)
    : ICommandHandler<AddWeatherEventParticipantCommand>
{
    public async Task<Result> Handle(AddWeatherEventParticipantCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
        StormTracker stormTracker = await dbContext.FindAsync<StormTracker>(request.StormTrackerId, cancellationToken);

        var participant = new WeatherEventParticipant
        {
            Event = weatherEvent,
            Tracker = stormTracker,
            ParticipationMethod = request.ParticipationMethod
        };

        weatherEvent.AddParticipant(participant);

        await dbContext.CommitAsync(cancellationToken);

        return Result.Ok();
    }
}
