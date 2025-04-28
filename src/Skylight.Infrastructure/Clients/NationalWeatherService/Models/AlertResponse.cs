using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// The code denoting the type of action recommended for the target audience. This corresponds to <c>responseType</c> in the CAP specification. 
/// </summary>
public enum AlertResponse
{
	None,
	AllClear,
	Assess,
	Monitor,
	Avoid,
	Execute,
	Prepare,
	Evacuate,
	Shelter
}

public static class AlertResponseExtensions
{
	public static Domain.Alerts.Entities.AlertResponse ToCore(this AlertResponse client) =>
		client switch
		{
			AlertResponse.None => Domain.Alerts.Entities.AlertResponse.None,
			AlertResponse.AllClear => Domain.Alerts.Entities.AlertResponse.AllClear,
			AlertResponse.Assess => Domain.Alerts.Entities.AlertResponse.Assess,
			AlertResponse.Monitor => Domain.Alerts.Entities.AlertResponse.Monitor,
			AlertResponse.Avoid => Domain.Alerts.Entities.AlertResponse.Avoid,
			AlertResponse.Execute => Domain.Alerts.Entities.AlertResponse.Execute,
			AlertResponse.Prepare => Domain.Alerts.Entities.AlertResponse.Prepare,
			AlertResponse.Evacuate => Domain.Alerts.Entities.AlertResponse.Evacuate,
			AlertResponse.Shelter => Domain.Alerts.Entities.AlertResponse.Shelter,
			_ => throw new InvalidEnumCastException<Domain.Alerts.Entities.AlertResponse>(client)
		};
}
