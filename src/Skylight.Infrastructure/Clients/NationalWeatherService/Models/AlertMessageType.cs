using Skylight.Domain.Common.Exceptions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Alert message type.
/// </summary>
public enum AlertMessageType
{
	Alert,
	Update,
	Cancel,
	Error
}

public static class AlertMessageTypeExtensions
{
	public static Domain.Alerts.Entities.AlertMessageType ToCore(this AlertMessageType client) =>
		client switch
		{
			AlertMessageType.Alert => Domain.Alerts.Entities.AlertMessageType.Alert,
			AlertMessageType.Update => Domain.Alerts.Entities.AlertMessageType.Update,
			AlertMessageType.Cancel => Domain.Alerts.Entities.AlertMessageType.Cancellation,
			AlertMessageType.Error => Domain.Alerts.Entities.AlertMessageType.Error,
			_ => throw new InvalidEnumCastException<Domain.Alerts.Entities.AlertMessageType>(client)
		};
}
