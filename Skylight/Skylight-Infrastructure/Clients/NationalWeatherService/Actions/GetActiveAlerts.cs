using FluentValidation;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Actions;

public sealed record GetActiveAlertsRequest(
	AlertStatus[]? Statuses = null,
	AlertMessageType[]? MessageTypes = null,
	string[]? EventNames = null,
	string[]? EventCodes = null,
	AlertLocation? Location = null,
	AlertUrgency[]? Urgencies = null,
	AlertSeverity[]? Severities = null,
	AlertCertainty[]? Certainties = null,
	int Limit = 100)
	: IClientRequest;

public sealed record GetActiveAlertsResponse(AlertCollection AlertCollection)
	: IClientResponse;

public class GetActiveAlertsRequestValidator : AbstractValidator<GetActiveAlertsRequest>
{
	public GetActiveAlertsRequestValidator()
	{
		RuleForEach(x => x.EventCodes)
			.Matches(@"^\w{3}$");

		RuleFor(x => x.Location)
			.SetInheritanceValidator(v =>
			{
				v.Add(new AreaAlertLocationValidator());
				v.Add(new ZoneAlertLocationValidator());
			});

		RuleFor(x => x.Limit)
			.GreaterThan(0);
	}
}
