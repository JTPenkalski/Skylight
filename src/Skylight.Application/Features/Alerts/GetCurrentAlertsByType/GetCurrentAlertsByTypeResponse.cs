using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Application.Features.Alerts.GetCurrentAlertsByType;

public sealed record GetCurrentAlertsByTypeResponse(
	int Count,
	string AlertCode,
	string AlertName,
	Level AlertLevel,
	IEnumerable<GetCurrentAlertsByTypeResponse.CurrentAlertByType> CurrentAlerts) : IResponse
{
	public sealed record CurrentAlertByType(
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
