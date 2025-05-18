using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Extensions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Queries;

public sealed record GetCurrentAlertLocationSummariesQuery : IQuery<GetCurrentAlertLocationSummariesResponse>;

public sealed record GetCurrentAlertLocationSummariesResponse(IEnumerable<GetCurrentAlertLocationSummariesResponse.CurrentAlertLocationSummary> Locations) : IResponse
{
	public sealed record CurrentAlertLocationSummary(
		string Code,
		string Name,
		DateTimeOffset EffectiveTime,
		DateTimeOffset ExpirationTime,
		AlertThreat MaxThreat,
		int TotalAlerts,
		int TornadoWarnings,
		int SevereThunderstormWarnings,
		int FlashFloodWarnings,
		int SpecialWeatherStatements,
		float MaxHail,
		float MaxWind,
		bool Tornadoes);
}

public class GetCurrentAlertLocationSummariesHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertLocationSummariesQuery, GetCurrentAlertLocationSummariesResponse>
{
	public async ValueTask<Result<GetCurrentAlertLocationSummariesResponse>> Handle(GetCurrentAlertLocationSummariesQuery request, CancellationToken cancellationToken)
	{
		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Include(x => x.Type)
			.Include(x => x.Parameters)
			.Include(x => x.Zones)
				.ThenInclude(x => x.Zone)
			.Where(x =>
				x.ExpiresOn > DateTimeOffset.UtcNow
				&& !x.DeletedOn.HasValue)
			.ToListAsync(cancellationToken);

		var alertZones = alerts
			.SelectMany(x => x.Zones)
			.GroupBy(x => x.Zone)
			.ToDictionary(
				x => x.Key,
				x => x.Select(x => x.Alert).ToList());

		var summaries = GetLocationSummaries(alertZones);
		var response = new GetCurrentAlertLocationSummariesResponse(summaries);

		return Result.Success(response);
	}

	internal virtual List<GetCurrentAlertLocationSummariesResponse.CurrentAlertLocationSummary> GetLocationSummaries(Dictionary<Zone, List<Alert>> alertZones)
	{
		var summaries = new List<GetCurrentAlertLocationSummariesResponse.CurrentAlertLocationSummary>();

		foreach (var alertZone in alertZones)
		{
			DateTimeOffset effectiveTime = alertZone.Value.MinBy(x => x.EffectiveOn)?.EffectiveOn ?? DateTimeOffset.MinValue;
			DateTimeOffset expirationTime = alertZone.Value.MaxBy(x => x.ExpiresOn)?.ExpiresOn ?? DateTimeOffset.MinValue;

			Dictionary<string, int> alertTypeCounts = alertZone.Value
				.CountBy(x => x.Type.TypeCode)
				.ToDictionary();

			int totalAlerts = alertZone.Value.Count;
			alertTypeCounts.TryGetValue(AlertTypeCodes.TornadoWarning, out int tornadoWarnings);
			alertTypeCounts.TryGetValue(AlertTypeCodes.SevereThunderstormWarning, out int severeThunderstormWarnings);
			alertTypeCounts.TryGetValue(AlertTypeCodes.FlashFloodWarning, out int flashFloodWarnings);
			alertTypeCounts.TryGetValue(AlertTypeCodes.SpecialWeatherStatement, out int specialWeatherStatements);

			float maxHail = alertZone.Value
				.SelectMany(x => x.Parameters)
				.Where(x => x.Key == AlertParameterKey.MaxHailSize)
				.Select(x => float.Parse(x.Value.ToNumeric()))
				.Union([0f])
				.Max();

			float maxWind = alertZone.Value
				.SelectMany(x => x.Parameters)
				.Where(x => x.Key == AlertParameterKey.MaxWindGust)
				.Select(x => float.Parse(x.Value.ToNumeric()))
				.Union([0f])
				.Max();

			bool tornadoes = alertZone.Value.Any(x => x.HasParameter(AlertParameterKey.TornadoDetection));

			AlertThreat maxThreat = alertZone.Value.MaxBy(x => x.Threat)?.Threat ?? AlertThreat.Unknown;

			var summary = new GetCurrentAlertLocationSummariesResponse.CurrentAlertLocationSummary(
				alertZone.Key.Code,
				alertZone.Key.Name,
				effectiveTime,
				expirationTime,
				maxThreat,
				totalAlerts,
				tornadoWarnings,
				severeThunderstormWarnings,
				flashFloodWarnings,
				specialWeatherStatements,
				maxHail,
				maxWind,
				tornadoes);

			summaries.Add(summary);
		}

		return summaries;
	}
}
