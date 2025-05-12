using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Queries;

public sealed record GetCurrentAlertParameterValuesByParameterQuery(AlertParameterKey ParameterKey) : IQuery<GetCurrentAlertParameterValuesByParameterResponse>;

public sealed record GetCurrentAlertParameterValuesByParameterResponse(
	IEnumerable<string> ParameterValues,
	IEnumerable<GetCurrentAlertParameterValuesByParameterResponse.CurrentAlertParameterCount> ParameterCounts)
	: IResponse
{
	public sealed record CurrentAlertParameterCount(string ParameterValue, int Count);
}

public class GetCurrentAlertParameterValuesByParameterHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertParameterValuesByParameterQuery, GetCurrentAlertParameterValuesByParameterResponse>
{
	public async ValueTask<Result<GetCurrentAlertParameterValuesByParameterResponse>> Handle(GetCurrentAlertParameterValuesByParameterQuery request, CancellationToken cancellationToken)
	{
		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Where(x =>
				x.ExpiresOn > DateTimeOffset.UtcNow
				&& !x.DeletedOn.HasValue)
			.SelectMany(x => x.Parameters)
			.Where(x => x.Key == request.ParameterKey)
			.ToListAsync(cancellationToken);

		var counts = GetObservationTypeCounts(alerts);

		var response = new GetCurrentAlertParameterValuesByParameterResponse(
			counts
				.Select(x => x.ParameterValue)
				.Distinct(),
			counts);

		return Result.Success(response);
	}

	internal virtual List<GetCurrentAlertParameterValuesByParameterResponse.CurrentAlertParameterCount> GetObservationTypeCounts(List<AlertParameter> alertParameters)
	{
		var counts = alertParameters
			.CountBy(x => x.Value)
			.Select(x => new GetCurrentAlertParameterValuesByParameterResponse.CurrentAlertParameterCount(x.Key.ToString(), x.Value))
			.OrderBy(x => x.ParameterValue)
			.ToList();

		return counts;
	}
}
