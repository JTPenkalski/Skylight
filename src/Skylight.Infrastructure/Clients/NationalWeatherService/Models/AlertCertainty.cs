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
	public static Certainty ToCore(this AlertCertainty client) =>
		client switch
		{
			AlertCertainty.Unknown => Certainty.Unknown,
			AlertCertainty.Unlikely => Certainty.Unlikely,
			AlertCertainty.Possible => Certainty.Possible,
			AlertCertainty.Likely => Certainty.Likely,
			AlertCertainty.Observed => Certainty.Observed,
			_ => throw new InvalidEnumCastException<Certainty>(client)
		};
}
