using FluentValidation;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Application.Features.Interfaces;

namespace Skylight.Application.Features.Alerts.GetCurrentAlertsByType;

public record GetCurrentAlertsByTypeQuery(string Code) : IQuery<GetCurrentAlertsByTypeResponse>;

public class GetCurrentAlertsByTypeQueryValidator : AbstractValidator<GetCurrentAlertsByTypeQuery>
{
	public GetCurrentAlertsByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();
	}
}