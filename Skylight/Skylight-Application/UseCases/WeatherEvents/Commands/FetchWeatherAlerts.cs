using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents.Commands;

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
    ISkylightContext context,
    IWeatherAlertService alertService)
    : ICommandHandler<FetchWeatherAlertsCommand, FetchWeatherAlertsResponse>
{
    public async Task<Result<FetchWeatherAlertsResponse>> Handle(FetchWeatherAlertsCommand request, CancellationToken cancellationToken)
    {
		var newWeatherEventAlerts = new List<FetchWeatherAlertsResponse.NewWeatherEventAlert>();

		WeatherEvent weatherEvent = await context.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
		IEnumerable<WeatherEventAlert> alerts = await alertService.GetActiveAlertsForEventAsync(weatherEvent, cancellationToken);

        foreach (WeatherEventAlert alert in alerts)
        {
			weatherEvent.AddAlert(alert);

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

			newWeatherEventAlerts.Add(newWeatherEventAlert);
		}

        await context.CommitAsync(cancellationToken);

		var response = new FetchWeatherAlertsResponse
		{
			NewWeatherEventAlerts = newWeatherEventAlerts
		};

		return Result.Ok(response);
    }
}
