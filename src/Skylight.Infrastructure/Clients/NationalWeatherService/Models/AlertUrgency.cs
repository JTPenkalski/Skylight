using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Alert urgency.
/// </summary>
public enum AlertUrgency
{
	Unknown,
	Past,
	Future,
	Expected,
	Immediate
}

public static class AlertUrgencyExtensions
{
	public static Domain.Alerts.Entities.AlertUrgency ToCore(this AlertUrgency client) =>
		client switch
		{
			AlertUrgency.Unknown => Domain.Alerts.Entities.AlertUrgency.Unknown,
			AlertUrgency.Past => Domain.Alerts.Entities.AlertUrgency.Past,
			AlertUrgency.Future => Domain.Alerts.Entities.AlertUrgency.Future,
			AlertUrgency.Expected => Domain.Alerts.Entities.AlertUrgency.Expected,
			AlertUrgency.Immediate => Domain.Alerts.Entities.AlertUrgency.Immediate,
			_ => throw new InvalidEnumCastException<Domain.Alerts.Entities.AlertUrgency>(client)
		};
}
