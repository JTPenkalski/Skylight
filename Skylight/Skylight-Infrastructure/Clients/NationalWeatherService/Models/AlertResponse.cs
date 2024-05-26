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
