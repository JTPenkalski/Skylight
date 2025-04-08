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
	public static Severity ToCore(this AlertSeverity client) =>
		client switch
		{
			AlertSeverity.Unknown => Severity.Unknown,
			AlertSeverity.Minor => Severity.Minor,
			AlertSeverity.Moderate => Severity.Moderate,
			AlertSeverity.Severe => Severity.Severe,
			AlertSeverity.Extreme => Severity.Extreme,
			_ => throw new InvalidEnumCastException<Severity>(client)
		};
}
