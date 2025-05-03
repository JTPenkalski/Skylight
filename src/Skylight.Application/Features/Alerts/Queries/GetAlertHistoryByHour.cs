using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;
using Skylight.Domain.Common.Extensions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Queries;

public record GetHourlyAlertCountsByTypeQuery(string Code, DateTimeOffset Start, int PastHours) : IQuery<GetHourlyAlertCountsByTypeResponse>;

public class GetHourlyAlertCountsByTypeQueryValidator : AbstractValidator<GetHourlyAlertCountsByTypeQuery>
{
	public GetHourlyAlertCountsByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();

		RuleFor(x => x.PastHours)
			.GreaterThan(0);
	}
}

public sealed record GetHourlyAlertCountsByTypeResponse(
	string AlertCode,
	string AlertName,
	IEnumerable<GetHourlyAlertCountsByTypeResponse.HourlyCount> AlertCounts)
	: IResponse
{
	public record HourlyCount(int Hour, int Count);
}

public class GetHourlyAlertCountsByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetHourlyAlertCountsByTypeQuery, GetHourlyAlertCountsByTypeResponse>
{
	private readonly record struct Point(DateTimeOffset DateTime, bool IsNew);

	public async ValueTask<Result<GetHourlyAlertCountsByTypeResponse>> Handle(GetHourlyAlertCountsByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Code == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		DateTimeOffset maxTime = request.Start.ToNextHour().ToUniversalTime();
		DateTimeOffset minTime = maxTime.AddHours(-request.PastHours);

		var counts = await dbContext.Alerts
			.AsNoTracking()
			.Where(x =>
				x.Type.Code == request.Code
				&& x.ExpiresOn >= minTime
				&& x.EffectiveOn < maxTime
				&& !x.DeletedOn.HasValue)
			.SelectMany(x => new Point[] { new(x.EffectiveOn, true), new(x.ExpiresOn, false) })
			.OrderBy(x => x.DateTime)
			.ToListAsync(cancellationToken);

		var response = new GetHourlyAlertCountsByTypeResponse(
			alertType.Code,
			alertType.Name,
			allCounts);

		return Result.Success(response);
	}
}
