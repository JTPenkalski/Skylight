using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record FetchWeatherAlertsCommand(Guid WeatherEventId) : ICommand<FetchWeatherAlertsResponse>;

public sealed record FetchWeatherAlertsResponse : IResponse
{
	public required IEnumerable<NewWeatherEventAlert> NewWeatherEventAlerts { get; init; }

	public sealed record NewWeatherEventAlert(
		string Sender,
		string Headline,
		string Instruction,
		string Description,
		DateTimeOffset Sent,
		DateTimeOffset Effective,
		DateTimeOffset Expires,
		string Name,
		string Source,
		WeatherAlertLevel Level,
		string? Code = null);
}

public class FetchWeatherAlertsCommandHandler(
    ISkylightContext dbContext,
    IWeatherAlertService alertService)
    : ICommandHandler<FetchWeatherAlertsCommand, FetchWeatherAlertsResponse>
{
    public async Task<Result<FetchWeatherAlertsResponse>> Handle(FetchWeatherAlertsCommand request, CancellationToken cancellationToken)
    {
		var newAlerts = new List<FetchWeatherAlertsResponse.NewWeatherEventAlert>();

		WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
		IEnumerable<WeatherEventAlert> alerts = await alertService.GetActiveAlertsForEventAsync(weatherEvent, cancellationToken);

        foreach (WeatherEventAlert alert in alerts)
        {
			bool addedAlert = weatherEvent.AddAlert(alert);

			if (addedAlert)
			{
				var newWeatherEventAlert = new FetchWeatherAlertsResponse.NewWeatherEventAlert(
					alert.Sender,
					alert.Headline,
					alert.Instruction,
					alert.Description,
					alert.Sent,
					alert.Effective,
					alert.Expires,
					alert.Alert.Name,
					alert.Alert.Source,
					alert.Alert.Level,
					alert.Alert.Code);

				newAlerts.Add(newWeatherEventAlert);
			}
		}

        await dbContext.CommitAsync(cancellationToken);

		var response = new FetchWeatherAlertsResponse
		{
			NewWeatherEventAlerts = newAlerts
		};

		return Result.Ok(response);
    }
}
