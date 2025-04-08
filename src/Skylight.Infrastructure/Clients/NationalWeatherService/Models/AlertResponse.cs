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
	public static Response ToCore(this AlertResponse client) =>
		client switch
		{
			AlertResponse.None => Response.None,
			AlertResponse.AllClear => Response.AllClear,
			AlertResponse.Assess => Response.Assess,
			AlertResponse.Monitor => Response.Monitor,
			AlertResponse.Avoid => Response.Avoid,
			AlertResponse.Execute => Response.Execute,
			AlertResponse.Prepare => Response.Prepare,
			AlertResponse.Evacuate => Response.Evacuate,
			AlertResponse.Shelter => Response.Shelter,
			_ => throw new InvalidEnumCastException<Response>(client)
		};
}
