using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Validators;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Queries;

public sealed record GetCurrentAlertObservationTypesByTypeQuery(string Code) : IQuery<GetCurrentAlertObservationTypesByTypeResponse>;

public class GetCurrentAlertObservationTypesByTypeQueryValidator : AbstractValidator<GetCurrentAlertObservationTypesByTypeQuery>
{
	public GetCurrentAlertObservationTypesByTypeQueryValidator()
	{
		RuleFor(x => x.Code)
			.IsSameEventCode();
	}
}

public sealed record GetCurrentAlertObservationTypesByTypeResponse(
	string AlertCode,
	string AlertName,
	IEnumerable<string> ObservationTypes,
	IEnumerable<GetCurrentAlertObservationTypesByTypeResponse.CurrentAlertObservationTypeCount> ObservationTypeCounts)
	: IResponse
{
	public sealed record CurrentAlertObservationTypeCount(string ObservationType, int Count);
}

public class GetCurrentAlertObservationTypesByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertObservationTypesByTypeQuery, GetCurrentAlertObservationTypesByTypeResponse>
{
	public async ValueTask<Result<GetCurrentAlertObservationTypesByTypeResponse>> Handle(GetCurrentAlertObservationTypesByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => (x.EventCode ?? x.ProductCode) == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Include(x => x.Parameters)
			.Where(x =>
				x.Type == alertType
				&& x.ExpiresOn > DateTimeOffset.UtcNow
				&& !x.DeletedOn.HasValue)
			.ToListAsync(cancellationToken);

		var counts = GetSevereThunderstormWarningCounts(alerts);

		var response = new GetCurrentAlertObservationTypesByTypeResponse(
			alertType.ProductCode,
			alertType.Name,
			counts
				.Select(x => x.ObservationType)
				.Distinct(),
			counts);

		return Result.Success(response);
	}

	internal virtual List<GetCurrentAlertObservationTypesByTypeResponse.CurrentAlertObservationTypeCount> GetSevereThunderstormWarningCounts(List<Alert> alerts)
	{
		AlertParameterKey[] observationTypes = [AlertParameterKey.HailThreat, AlertParameterKey.WindThreat, AlertParameterKey.TornadoDetection, AlertParameterKey.TypeModifier];

		var counts = alerts
			.SelectMany(x => x.Parameters)
			.Where(x => observationTypes.Contains(x.Key))
			.CountBy(x => x.Value)
			.Select(x => new GetCurrentAlertObservationTypesByTypeResponse.CurrentAlertObservationTypeCount(x.Key.ToString(), x.Value))
			.ToList();

		return counts;
	}
}
