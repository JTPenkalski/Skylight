using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record GetWeatherAlertsByEventIdQuery(Guid WeatherEventId)
	: IQuery<GetWeatherAlertsByEventIdResponse>;

public sealed record GetWeatherAlertsByEventIdResponse : IResponse
{
	public required IEnumerable<WeatherEventAlert> WeatherEventAlerts { get; init; }

	public sealed record WeatherEventAlert(
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
		string? Code = null,
		IEnumerable<WeatherEventAlertLocation>? Locations = null);

	public sealed record WeatherEventAlertLocation(
		string Name,
		string? State = null);
}

public class GetWeatherAlertsByEventIdQueryHandler(ISkylightContext dbContext) : IQueryHandler<GetWeatherAlertsByEventIdQuery, GetWeatherAlertsByEventIdResponse>
{
	public async Task<Result<GetWeatherAlertsByEventIdResponse>> Handle(GetWeatherAlertsByEventIdQuery request, CancellationToken cancellationToken)
	{
		var alerts = new List<GetWeatherAlertsByEventIdResponse.WeatherEventAlert>();
		IEnumerable<WeatherEventAlert> weatherEventAlerts = (await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken))?.Alerts ?? [];

		foreach (WeatherEventAlert weatherEventAlert in weatherEventAlerts)
		{
			var alert = new GetWeatherAlertsByEventIdResponse.WeatherEventAlert(
				weatherEventAlert.Sender,
				weatherEventAlert.Headline,
				weatherEventAlert.Instruction,
				weatherEventAlert.Description,
				weatherEventAlert.Sent,
				weatherEventAlert.Effective,
				weatherEventAlert.Expires,
				weatherEventAlert.Alert.Name,
				weatherEventAlert.Alert.Source,
				weatherEventAlert.Alert.Level,
				weatherEventAlert.Alert.Code,
				weatherEventAlert.Locations
					.Select(x => new GetWeatherAlertsByEventIdResponse.WeatherEventAlertLocation(
						x.Name,
						x.State)));

			alerts.Add(alert);
		}

		var response = new GetWeatherAlertsByEventIdResponse
		{
			WeatherEventAlerts = alerts
		};

		return Result.Ok(response);
	}
}
