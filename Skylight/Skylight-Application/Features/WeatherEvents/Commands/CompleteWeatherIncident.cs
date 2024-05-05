using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.Features.WeatherEvents;

public sealed record CompleteWeatherIncidentCommand(Guid WeatherIncidentId)
    : ICommand;

public class CompleteWeatherIncidentCommandHandler(
    ISkylightContext context,
    TimeProvider timeProvider)
    : ICommandHandler<CompleteWeatherIncidentCommand>
{
    public async Task<Result> Handle(CompleteWeatherIncidentCommand request, CancellationToken cancellationToken)
    {
        WeatherIncident? weatherIncident = await context.WeatherIncidents.FindAsync([request.WeatherIncidentId], cancellationToken);

        if (weatherIncident is not null)
        {
            weatherIncident.EndDate = timeProvider.GetUtcNow();

            await context.CommitAsync(cancellationToken);
        }

        return Result.FailIf(weatherIncident is null, $"{nameof(WeatherIncident)} was not found.");
    }
}
