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

public sealed record GetHistoricalAlertCountsByTypeQuery(string Code, DateTimeOffset Start, int PastHours) : IQuery<GetHistoricalAlertCountsByTypeResponse>;

public class GetHistoricalAlertCountsByTypeQueryValidator : AbstractValidator<GetHistoricalAlertCountsByTypeQuery>
{
	public GetHistoricalAlertCountsByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();

		RuleFor(x => x.PastHours)
			.GreaterThan(0);
	}
}

public sealed record GetHistoricalAlertCountsByTypeResponse(
	string AlertName,
	AlertLevel AlertLevel,
	IEnumerable<GetHistoricalAlertCountsByTypeResponse.HistoricalAlertCount> AlertCounts) : IResponse
{
	public sealed record HistoricalAlertCount(DateTimeOffset DateTime, int Count);
}

public class GetHistoricalAlertCountsByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetHistoricalAlertCountsByTypeQuery, GetHistoricalAlertCountsByTypeResponse>
{
	public record AlertSpan(DateTimeOffset EffectiveOn, DateTimeOffset ExpiresOn);
	public record AlertPoint(DateTimeOffset DateTime, bool IsEffective);

	public async ValueTask<Result<GetHistoricalAlertCountsByTypeResponse>> Handle(GetHistoricalAlertCountsByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => (x.EventCode ?? x.ProductCode) == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		DateTimeOffset maxTime = request.Start.ToUniversalTime();
		DateTimeOffset minTime = maxTime.AddHours(-request.PastHours);

		var alertTimings = await dbContext.Alerts
			.AsNoTracking()
			.Where(x =>
				x.Type == alertType
				&& x.ExpiresOn >= minTime
				&& x.EffectiveOn < maxTime
				&& !x.DeletedOn.HasValue)
			.Select(x => new AlertSpan(x.EffectiveOn, x.ExpiresOn))
			.ToListAsync(cancellationToken);

		var historicalAlertCounts = GetHistoricalAlertCounts(minTime, maxTime, alertTimings);

		var response = new GetHistoricalAlertCountsByTypeResponse(
			alertType.Name,
			alertType.Level,
			historicalAlertCounts);

		return Result.Success(response);
	}

	internal virtual List<GetHistoricalAlertCountsByTypeResponse.HistoricalAlertCount> GetHistoricalAlertCounts(DateTimeOffset minTime, DateTimeOffset maxTime, List<AlertSpan> spans)
	{
		int totalCount = 0;
		var historicalCounts = spans
			// Convert the time spans of the alerts into individual points
			.SelectMany(x => new AlertPoint[]
			{
				new(x.EffectiveOn, true),
				new(x.ExpiresOn, false)
			})
			// Sort the points in chronological order
			.OrderBy(x => x.DateTime)
			// Calculate the total count of alerts at each point
			.Aggregate(
				// Seed with the lower bound, in case there are no alerts already in progress
				new Dictionary<DateTimeOffset, int>
				{
					[minTime] = totalCount,
				},
				(history, item) =>
				{
					DateTimeOffset key = item.DateTime.Clamp(minTime, maxTime);
					int addend = item.IsEffective ? 1 : -1;

					// Ignore changes that happen in the future
					if (item.DateTime < maxTime)
					{
						totalCount += addend;
					}

					history[key] = totalCount;

					return history;
				})
			// Add a default upper bound, in case there are no alerts still in progress
			.Union(new Dictionary<DateTimeOffset, int>
			{
				[maxTime] = totalCount,
			})
			// Map to the output type
			.Select(x => new GetHistoricalAlertCountsByTypeResponse.HistoricalAlertCount(x.Key, x.Value))
			.ToList();

		return historicalCounts;
	}
}
