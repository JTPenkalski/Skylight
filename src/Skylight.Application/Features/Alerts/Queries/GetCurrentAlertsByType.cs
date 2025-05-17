using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Queries;

public sealed record GetCurrentAlertsByTypeQuery(string Code) : IQuery<GetCurrentAlertsByTypeResponse>;

public class GetCurrentAlertsByTypeQueryValidator : AbstractValidator<GetCurrentAlertsByTypeQuery>
{
	public GetCurrentAlertsByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();
	}
}

public sealed record GetCurrentAlertsByTypeResponse(
	int Count,
	string AlertCode,
	string AlertName,
	AlertLevel AlertLevel,
	IEnumerable<GetCurrentAlertsByTypeResponse.CurrentAlert> CurrentAlerts)
	: IResponse
{
	public sealed record CurrentAlertLocation(string Zone, string Name);
	public sealed record CurrentAlertParameter(AlertParameterKey Key, string Value);

	public sealed record CurrentAlert(
		string ObservationType,
		string SenderCode,
		string SenderName,
		string Headline,
		string Description,
		string Instruction,
		DateTimeOffset Sent,
		DateTimeOffset Effective,
		DateTimeOffset Expires,
		AlertSeverity Severity,
		AlertCertainty Certainty,
		AlertUrgency Urgency,
		AlertResponse Response,
		IEnumerable<CurrentAlertLocation> Locations,
		IEnumerable<CurrentAlertParameter> Parameters);
}

public class GetCurrentAlertsByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertsByTypeQuery, GetCurrentAlertsByTypeResponse>
{
	public async ValueTask<Result<GetCurrentAlertsByTypeResponse>> Handle(GetCurrentAlertsByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.TypeCode == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Include(x => x.Type)
			.Include(x => x.Parameters)
			.Where(x =>
				x.Type == alertType
				&& x.ExpiresOn > DateTimeOffset.UtcNow
				&& !x.DeletedOn.HasValue)
			.OrderBy(x => x.EffectiveOn)
			.Select(x => new GetCurrentAlertsByTypeResponse.CurrentAlert(
				x.ObservationType,
				x.Sender.Code,
				x.Sender.Name,
				x.Headline,
				x.Description,
				x.Instruction,
				x.SentOn,
				x.EffectiveOn,
				x.ExpiresOn,
				x.Severity,
				x.Certainty,
				x.Urgency,
				x.Response,
				x.Zones
					.OrderBy(x => x.Zone.Code)
					.Select(x => new GetCurrentAlertsByTypeResponse.CurrentAlertLocation(x.Zone.Code, x.Zone.Name)),
				x.Parameters
					.OrderBy(x => x.Key)
					.Select(x => new GetCurrentAlertsByTypeResponse.CurrentAlertParameter(x.Key, x.Value))))
			.ToListAsync(cancellationToken);

		var response = new GetCurrentAlertsByTypeResponse(
			alerts.Count,
			alertType.ProductCode,
			alertType.Name,
			alertType.Level,
			alerts);

		return Result.Success(response);
	}
}
