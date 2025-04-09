using Skylight.Application.Features.Interfaces;

namespace Skylight.Application.Features.Alerts.GetAlertSenders;

public record GetAlertSendersResponse(IEnumerable<GetAlertSendersResponse.AlertSender> Senders) : IResponse
{
	public record AlertSender(
		string Code,
		string Name);
}
