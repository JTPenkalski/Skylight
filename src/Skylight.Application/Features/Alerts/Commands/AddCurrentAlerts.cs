using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Application.Services;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Commands;

public sealed record AddCurrentAlertsCommand : ICommand<AddCurrentAlertsResponse>;

public sealed record AddCurrentAlertsResponse(IEnumerable<AddCurrentAlertsResponse.CurrentAlert> CurrentAlerts) : IResponse
{
	public sealed record CurrentAlert(
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
		IEnumerable<string> Zones);
}

public class AddCurrentAlertsHandler(
	ISkylightDbContext dbContext,
	IWeatherAlertService weatherAlertService)
	: ICommandHandler<AddCurrentAlertsCommand, AddCurrentAlertsResponse>
{
	public async ValueTask<Result<AddCurrentAlertsResponse>> Handle(AddCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		var currentAlerts = new List<AddCurrentAlertsResponse.CurrentAlert>();

		List<Alert> activeAlerts = await weatherAlertService.GetActiveAlertsAsync(cancellationToken);

		HashSet<string?> activeAlertIds = [.. activeAlerts.Select(x => x.ExternalId)];
		HashSet<Alert> existingAlerts = await dbContext.Alerts
			.Where(x => activeAlertIds.Contains(x.ExternalId))
			.ToHashSetAsync(cancellationToken);

		foreach (Alert alert in activeAlerts)
		{
			if (!existingAlerts.Contains(alert))
			{
				await dbContext.Alerts.AddAsync(alert, cancellationToken);
			}

			var newWeatherEventAlert = new AddCurrentAlertsResponse.CurrentAlert(
				AlertCode: alert.Type.Code,
				AlertName: alert.Type.Name,
				AlertLevel: alert.Type.Level,
				SenderCode: alert.Sender.Code,
				SenderName: alert.Sender.Name,
				Headline: alert.Headline,
				Description: alert.Description,
				Instruction: alert.Instruction,
				Sent: alert.SentOn,
				Effective: alert.EffectiveOn,
				Expires: alert.ExpiresOn,
				Type: alert.MessageType,
				Severity: alert.Severity,
				Certainty: alert.Certainty,
				Urgency: alert.Urgency,
				Response: alert.Response,
				Zones: [.. alert.Zones.Select(x => x.Code)]);

			currentAlerts.Add(newWeatherEventAlert);
		}

		await dbContext.CommitAsync(cancellationToken);

		var response = new AddCurrentAlertsResponse(currentAlerts);

		return Result.Success(response);
	}
}
