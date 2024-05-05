using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.Features.WeatherEvents;

public sealed record CreateWeatherEventCommand(
    string Name,
    string Description,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate = null)
    : ICommand<Guid>;

public class CreateWeatherEventCommandHandler(ISkylightContext context)
    : ICommandHandler<CreateWeatherEventCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateWeatherEventCommand request, CancellationToken cancellationToken)
    {
        var weatherEvent = new WeatherEvent
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        await context.WeatherEvents.AddAsync(weatherEvent, cancellationToken);
        await context.CommitAsync();

        return Result.Ok(weatherEvent.Id);
    }
}
