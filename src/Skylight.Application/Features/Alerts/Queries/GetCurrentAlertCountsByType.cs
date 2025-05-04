using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Queries;

public sealed record GetCurrentAlertCountByTypeQuery(string Code) : IQuery<GetCurrentAlertCountByTypeResponse>;

public class GetCurrentAlertCountByTypeQueryValidator : AbstractValidator<GetCurrentAlertCountByTypeQuery>
{
	public GetCurrentAlertCountByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();
	}
}

public sealed record GetCurrentAlertCountByTypeResponse(
	int Count,
	string AlertCode,
	string AlertName,
	AlertLevel AlertLevel)
	: IResponse;

public class GetCurrentAlertCountByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertCountByTypeQuery, GetCurrentAlertCountByTypeResponse>
{
	public async ValueTask<Result<GetCurrentAlertCountByTypeResponse>> Handle(GetCurrentAlertCountByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Code == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Where(x =>
				x.Type.Code == request.Code
				&& x.ExpiresOn > DateTimeOffset.UtcNow
				&& !x.DeletedOn.HasValue)
			.ToListAsync(cancellationToken);

		var response = new GetCurrentAlertCountByTypeResponse(
			alerts.Count,
			alertType.Code,
			alertType.Name,
			alertType.Level);

		return Result.Success(response);
	}
}
