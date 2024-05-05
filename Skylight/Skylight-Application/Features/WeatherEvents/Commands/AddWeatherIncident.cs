using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.Features.WeatherEvents;

public sealed record AddWeatherIncidentCommand(
    Guid WeatherEventId,
    string Name,
    string Description,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate = null)
    : ICommand;

public class AddWeatherIncidentCommandHandler(ISkylightContext context)
    : ICommandHandler<AddWeatherIncidentCommand>
{
    public async Task<Result> Handle(AddWeatherIncidentCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent? weatherEvent = await context.WeatherEvents.FindAsync([request.WeatherEventId], cancellationToken);

        if (weatherEvent is not null)
        {
            var weatherIncident = new WeatherIncident
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            weatherEvent.Incidents.Add(weatherIncident);

            await context.CommitAsync(cancellationToken);
        }        

        return Result.FailIf(weatherEvent is null, $"{nameof(WeatherEvent)} was not found.");
    }
}
