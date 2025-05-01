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
		IEnumerable<string> Zones);
}

public class AddCurrentAlertsHandler(
	ISkylightDbContext dbContext,
	IWeatherAlertService weatherAlertService)
	: ICommandHandler<AddCurrentAlertsCommand, AddCurrentAlertsResponse>
{
	public async ValueTask<Result<AddCurrentAlertsResponse>> Handle(AddCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		var currentAlerts = new List<AddCurrentAlertsResponse.AddedAlert>();

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

			var newWeatherEventAlert = new AddCurrentAlertsResponse.AddedAlert(
				alert.Type.Code,
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
				[.. alert.Zones.Select(x => x.Code)]);

			currentAlerts.Add(newWeatherEventAlert);
		}

		await dbContext.CommitAsync(cancellationToken);

		var response = new AddCurrentAlertsResponse(currentAlerts);

		return Result.Success(response);
	}
}
