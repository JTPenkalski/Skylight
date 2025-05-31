using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Common.Data;
using Skylight.Application.Common.Features;
using Skylight.Application.Common.Results;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Application.Alerts.Queries;

public sealed record GetExpiredAlertCountByTypeQuery(string Code, DateTimeOffset BeginDate, DateTimeOffset? EndDate) : IQuery<GetExpiredAlertCountByTypeResponse>;

public class GetExpiredAlertCountByTypeQueryValidator : AbstractValidator<GetExpiredAlertCountByTypeQuery>
{
	public GetExpiredAlertCountByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();

		RuleFor(x => x.EndDate)
			.GreaterThanOrEqualTo(x => x.BeginDate)
			.When(x => x.EndDate.HasValue);
	}
}

public sealed record GetExpiredAlertCountByTypeResponse(
	int Count,
	string AlertCode,
	string AlertName,
	AlertLevel AlertLevel)
	: IResponse;

public class GetExpiredAlertCountByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetExpiredAlertCountByTypeQuery, GetExpiredAlertCountByTypeResponse>
{
	public async ValueTask<Result<GetExpiredAlertCountByTypeResponse>> Handle(GetExpiredAlertCountByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.TypeCode == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Where(x =>
				x.Type == alertType
				&& x.ExpiresOn >= request.BeginDate
				&& x.ExpiresOn <= request.EndDate
				&& !x.DeletedOn.HasValue)
			.ToListAsync(cancellationToken);

		foreach (Alert alert in alerts)
		{
			alert.Expire();
		}

		var response = new GetExpiredAlertCountByTypeResponse(
			alerts.Count,
			alertType.ProductCode,
			alertType.Name,
			alertType.Level);

		return Result.Success(response);
	}
}
