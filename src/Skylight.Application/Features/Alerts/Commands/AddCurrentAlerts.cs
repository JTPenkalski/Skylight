using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Application.Services;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Commands;

public sealed record AddCurrentAlertsCommand : ICommand<AddCurrentAlertsResponse>;

public sealed record AddCurrentAlertsResponse(IEnumerable<AddCurrentAlertsResponse.AddedAlert> AddedAlerts) : IResponse
{
	public sealed record AddedAlertParameter(AlertParameterKey Key, string Value);

	public sealed record AddedAlert(
		string AlertCode,
		string AlertName,
		AlertLevel AlertLevel,
		string SenderCode,
		string SenderName,
		string Headline,
		string Description,
		string Instruction,
		DateTimeOffset Sent,
		DateTimeOffset Effective,
		DateTimeOffset Expires,
		AlertMessageType Type,
		AlertSeverity Severity,
		AlertCertainty Certainty,
		AlertUrgency Urgency,
		AlertResponse Response,
		IEnumerable<string> Zones,
		IEnumerable<AddedAlertParameter> Parameters);
}

public class AddCurrentAlertsHandler(
	ISkylightDbContext dbContext,
	IWeatherAlertService weatherAlertService)
	: ICommandHandler<AddCurrentAlertsCommand, AddCurrentAlertsResponse>
{
	public async ValueTask<Result<AddCurrentAlertsResponse>> Handle(AddCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		List<Alert> activeAlerts = await weatherAlertService.GetActiveAlertsAsync(cancellationToken);

		HashSet<string?> activeAlertIds = [.. activeAlerts.Select(x => x.ExternalId)];
		HashSet<string> existingAlerts = await dbContext.Alerts
			.Where(x => activeAlertIds.Contains(x.ExternalId))
			.Select(x => x.ExternalId!)
			.ToHashSetAsync(cancellationToken);

		List<AddCurrentAlertsResponse.AddedAlert> addedAlerts = AddNewAlerts(activeAlerts, existingAlerts);

		await dbContext.CommitAsync(cancellationToken);

		var response = new AddCurrentAlertsResponse(addedAlerts);

		return Result.Success(response);
	}

	internal virtual List<AddCurrentAlertsResponse.AddedAlert> AddNewAlerts(List<Alert> activeAlerts, HashSet<string> existingAlertIds)
	{
		var addedAlerts = new List<AddCurrentAlertsResponse.AddedAlert>();

		foreach (Alert alert in activeAlerts)
		{
			if (alert.ExternalId is null || !existingAlertIds.Contains(alert.ExternalId))
			{
				dbContext.Alerts.Add(alert);

				var newWeatherEventAlert = new AddCurrentAlertsResponse.AddedAlert(
					alert.Type.ProductCode,
					alert.Type.Name,
					alert.Type.Level,
					alert.Sender.Code,
					alert.Sender.Name,
					alert.Headline,
					alert.Description,
					alert.Instruction,
					alert.SentOn,
					alert.EffectiveOn,
					alert.ExpiresOn,
					alert.MessageType,
					alert.Severity,
					alert.Certainty,
					alert.Urgency,
					alert.Response,
					alert.Zones
						.OrderBy(x => x.Zone.Name)
						.Select(x => x.Zone.Code),
					alert.Parameters
						.OrderBy(x => x.Key)
						.Select(x => new AddCurrentAlertsResponse.AddedAlertParameter(x.Key, x.Value)));

				addedAlerts.Add(newWeatherEventAlert);
			}
		}

		return addedAlerts;
	}
}
