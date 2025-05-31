using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Alert severity.
/// </summary>
public enum AlertSeverity
{
	Unknown,
	Minor,
	Moderate,
	Severe,
	Extreme
}

public static class AlertSeverityExtensions
{
	public static Domain.Alerts.Entities.AlertSeverity ToCore(this AlertSeverity client) =>
		client switch
		{
			AlertSeverity.Unknown => Domain.Alerts.Entities.AlertSeverity.Unknown,
			AlertSeverity.Minor => Domain.Alerts.Entities.AlertSeverity.Minor,
			AlertSeverity.Moderate => Domain.Alerts.Entities.AlertSeverity.Moderate,
			AlertSeverity.Severe => Domain.Alerts.Entities.AlertSeverity.Severe,
			AlertSeverity.Extreme => Domain.Alerts.Entities.AlertSeverity.Extreme,
			_ => throw new InvalidEnumCastException<Domain.Alerts.Entities.AlertSeverity>(client)
		};
}
