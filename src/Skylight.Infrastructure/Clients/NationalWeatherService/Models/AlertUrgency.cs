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
	public static Urgency ToCore(this AlertUrgency client) =>
		client switch
		{
			AlertUrgency.Unknown => Urgency.Unknown,
			AlertUrgency.Past => Urgency.Past,
			AlertUrgency.Future => Urgency.Future,
			AlertUrgency.Expected => Urgency.Expected,
			AlertUrgency.Immediate => Urgency.Immediate,
			_ => throw new InvalidEnumCastException<Urgency>(client)
		};
}
