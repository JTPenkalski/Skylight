using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record CreateWeatherEventCommand(
    string Name,
    string Description,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate = null)
    : ICommand<CreateWeatherEventResponse>;

public sealed record CreateWeatherEventResponse(
    Guid Id)
    : IResponse;

public class CreateWeatherEventCommandHandler(ISkylightContext context)
    : ICommandHandler<CreateWeatherEventCommand, CreateWeatherEventResponse>
{
    public async Task<Result<CreateWeatherEventResponse>> Handle(CreateWeatherEventCommand request, CancellationToken cancellationToken)
    {
        var weatherEvent = new WeatherEvent
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        await context.WeatherEvents.AddAsync(weatherEvent, cancellationToken);
        await context.CommitAsync(cancellationToken);

        var response = new CreateWeatherEventResponse(weatherEvent.Id);

        return Result.Ok(response);
    }
}
