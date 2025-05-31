using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Alert certainty.
/// </summary>
public enum AlertCertainty
{
	Unknown,
	Unlikely,
	Possible,
	Likely,
	Observed
}

public static class AlertCertaintyExtensions
{
	public static Domain.Alerts.Entities.AlertCertainty ToCore(this AlertCertainty client) =>
		client switch
		{
			AlertCertainty.Unknown => Domain.Alerts.Entities.AlertCertainty.Unknown,
			AlertCertainty.Unlikely => Domain.Alerts.Entities.AlertCertainty.Unlikely,
			AlertCertainty.Possible => Domain.Alerts.Entities.AlertCertainty.Possible,
			AlertCertainty.Likely => Domain.Alerts.Entities.AlertCertainty.Likely,
			AlertCertainty.Observed => Domain.Alerts.Entities.AlertCertainty.Observed,
			_ => throw new InvalidEnumCastException<Domain.Alerts.Entities.AlertCertainty>(client)
		};
}
