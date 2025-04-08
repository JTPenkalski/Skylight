using Skylight.Domain.Alerts.Entities;
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
	public static MessageType ToCore(this AlertMessageType client) =>
		client switch
		{
			AlertMessageType.Alert => MessageType.Alert,
			AlertMessageType.Update => MessageType.Update,
			AlertMessageType.Cancel => MessageType.Cancellation,
			AlertMessageType.Error => MessageType.Error,
			_ => throw new InvalidEnumCastException<MessageType>(client)
		};
}
