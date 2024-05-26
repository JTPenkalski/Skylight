using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents.Commands;

public sealed record UpdateWeatherEventAlertsCommand(Guid WeatherEventId) : ICommand;

public class UpdateWeatherEventAlertsCommandHandler(
    ISkylightContext context,
    IWeatherAlertService alertService)
    : ICommandHandler<UpdateWeatherEventAlertsCommand>
{
    public async Task<Result> Handle(UpdateWeatherEventAlertsCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await context.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
		IEnumerable<WeatherEventAlert> alerts = await alertService.GetActiveAlertsForEventAsync(weatherEvent, cancellationToken);

        foreach (WeatherEventAlert alert in alerts)
        {
			weatherEvent.AddAlert(alert);
        }

        await context.CommitAsync(cancellationToken);

        return Result.Ok();
    }
}
