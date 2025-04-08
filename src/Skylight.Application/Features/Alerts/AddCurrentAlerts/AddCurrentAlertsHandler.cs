using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Application.Services;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.AddCurrentAlerts;

public class AddCurrentAlertsHandler(
	ISkylightDbContext dbContext,
	IWeatherAlertService weatherAlertService)
	: ICommandHandler<AddCurrentAlertsCommand, AddCurrentAlertsResponse>
{
	public async ValueTask<Result<AddCurrentAlertsResponse>> Handle(AddCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		var currentAlerts = new List<AddCurrentAlertsResponse.CurrentAlert>();

		IEnumerable<Alert> alerts = await weatherAlertService.GetActiveAlertsAsync(cancellationToken);

		foreach (Alert alert in alerts)
		{
			Alert? existingAlert = await dbContext.Alerts
				.SingleOrDefaultAsync(x => x.ExternalId == alert.ExternalId, cancellationToken);

			if (existingAlert is null)
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
