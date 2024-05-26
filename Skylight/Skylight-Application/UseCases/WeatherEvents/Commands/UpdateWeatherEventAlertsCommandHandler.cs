using FluentResults;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents.Commands;

public sealed record UpdateWeatherEventAlertsCommand(Guid WeatherEventId) : ICommand;

public class UpdateWeatherEventAlertsCommandHandler(
    ISkylightContext context,
    INationalWeatherServiceClient nwsClient)
    : ICommandHandler<UpdateWeatherEventAlertsCommand>
{
    public async Task<Result> Handle(UpdateWeatherEventAlertsCommand request, CancellationToken cancellationToken)
    {
        WeatherEvent weatherEvent = await context.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
        IEnumerable<WeatherEventAlert> eventAlerts = await FetchAlertsFromNwsAsync(weatherEvent, cancellationToken);

        foreach (WeatherEventAlert alert in eventAlerts)
        {
            weatherEvent.AddAlert(alert);
        }

        await context.CommitAsync(cancellationToken);

        return Result.Ok();
    }

    protected virtual async Task<IEnumerable<WeatherEventAlert>> FetchAlertsFromNwsAsync(WeatherEvent weatherEvent, CancellationToken cancellationToken)
    {
        var eventAlerts = new List<WeatherEventAlert>();

        var clientRequest = new GetActiveAlertsRequest(
            Status: AlertStatus.Actual,
            Urgency: AlertUrgency.Immediate);

        GetActiveAlertsResponse clientResponse = await nwsClient.GetActiveAlertsAsync(clientRequest, cancellationToken);

        foreach (Alert alert in clientResponse.AlertCollection.Alerts)
        {
            WeatherAlert? weatherAlert = await context.WeatherAlerts
                .FirstOrDefaultAsync(x => x.Name == alert.Event, cancellationToken);

            if (weatherAlert is not null)
            {
                var weatherEventAlert = new WeatherEventAlert
                {
                    Sent = alert.Sent,
                    Effective = alert.Effective,
                    Onset = alert.Onset,
                    Expires = alert.Expires,
                    Ends = alert.Ends,
                    Event = weatherEvent,
                    Alert = weatherAlert,
                };

                eventAlerts.Add(weatherEventAlert);
            }
        }

        return eventAlerts;
    }
}
