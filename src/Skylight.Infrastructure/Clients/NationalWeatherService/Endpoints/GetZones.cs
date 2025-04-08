using FluentValidation;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Endpoints;

public sealed record GetZonesRequest(
	string[]? ZoneIds = null,
	ZoneType[]? ZoneTypes = null,
	bool IncludeGeometry = false,
	int Limit = 1000)
	: IClientRequest;

public sealed record GetZonesResponse(
	IReadOnlyList<Zone> Zones)
	: IClientResponse;

public class GetZonesRequestValidator : AbstractValidator<GetZonesRequest>
{
	public GetZonesRequestValidator()
	{
		RuleForEach(x => x.ZoneIds)
			.IsZoneId();

		RuleFor(x => x.Limit)
			.GreaterThan(0);
	}
}
