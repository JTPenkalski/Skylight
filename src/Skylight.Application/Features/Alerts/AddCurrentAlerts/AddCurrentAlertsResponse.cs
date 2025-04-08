using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Application.Features.Alerts.AddCurrentAlerts;

public sealed record AddCurrentAlertsResponse(IEnumerable<AddCurrentAlertsResponse.CurrentAlert> CurrentAlerts) : IResponse
{
	public sealed record CurrentAlert(
		string AlertCode,
		string AlertName,
		Level AlertLevel,
		string SenderCode,
		string SenderName,
		string Headline,
		string Description,
		string Instruction,
		DateTimeOffset Sent,
		DateTimeOffset Effective,
		DateTimeOffset Expires,
		MessageType Type,
		Severity Severity,
		Certainty Certainty,
		Urgency Urgency,
		Response Response,
		IEnumerable<string> Zones);
}
