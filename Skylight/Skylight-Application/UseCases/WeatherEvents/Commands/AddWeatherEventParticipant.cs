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

public class AddWeatherEventParticipantCommandHandler(ISkylightContext context)
    : ICommandHandler<AddWeatherEventParticipantCommand>
{
    public async Task<Result> Handle(AddWeatherEventParticipantCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await context.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
        StormTracker stormTracker = await context.FindAsync<StormTracker>(request.StormTrackerId, cancellationToken);

        var participant = new WeatherEventParticipant
        {
            Event = weatherEvent,
            Tracker = stormTracker,
            ParticipationMethod = request.ParticipationMethod
        };

        weatherEvent.AddParticipant(participant);

        await context.CommitAsync(cancellationToken);

        return Result.Ok();
    }
}
