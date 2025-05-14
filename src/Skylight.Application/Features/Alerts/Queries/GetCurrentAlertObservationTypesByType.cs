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

		var counts = GetObservationTypeCounts(alerts);

		var response = new GetCurrentAlertObservationTypesByTypeResponse(
			alertType.Name,
			counts
				.Select(x => x.ObservationType)
				.Distinct(),
			counts);

		return Result.Success(response);
	}

	internal virtual List<GetCurrentAlertObservationTypesByTypeResponse.CurrentAlertObservationTypeCount> GetObservationTypeCounts(List<Alert> alerts)
	{
		// Associate a priority with each observation type, from highest to lowest
		var observationTypes = new[]
		{
			AlertParameterKey.TornadoDamageThreat,
			AlertParameterKey.ThunderstormDamageThreat,
			AlertParameterKey.FlashFloodDamageThreat,
			AlertParameterKey.TornadoDetection,
			AlertParameterKey.FlashFloodDetection,
			AlertParameterKey.WindThreat,
			AlertParameterKey.HailThreat,
		}.Select((x, i) => new { Key = x, Priority = i });

		var counts = alerts
			// Get a list of each Parameter for each Alert
			.SelectMany(
				x => x.Parameters,
				(alert, parameter) =>
					new
					{
						Alert = alert,
						Parameter = parameter
					})
			// Associate each Parameter with the priority established above
			.Join(
				observationTypes,
				x => x.Parameter.Key,
				x => x.Key,
				(alertParameter, observation) =>
					new
					{
						alertParameter.Alert,
						alertParameter.Parameter,
						observation.Priority,
					})
			// Sort the Parameters according to their priority
			.OrderBy(x => x.Priority)
			// Group each Parameter with its Alert
			.GroupBy(x => x.Alert.Id)
			// Count how many of each observation type there is, based on the first Parameter from each Alert group (which should now have the highest priority)
			.CountBy(x => x.First().Parameter.Value)
			// Map to the output type
			.Select(x => new GetCurrentAlertObservationTypesByTypeResponse.CurrentAlertObservationTypeCount(x.Key.ToString(), x.Value))
			// Reverse so that lower priority observation types are ordered first, for consistency
			.Reverse()
			.ToList();

		return counts;
	}
}
