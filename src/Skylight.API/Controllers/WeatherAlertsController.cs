using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Skylight.API.Controllers;

[ApiController]
[ApiVersion(SkylightApiVersion.Current)]
public class WeatherAlertsController(ILogger<WeatherAlertsController> logger) : BaseController
{
	[HttpGet]
    public IEnumerable<string> GetActive()
    {
		logger.LogInformation("Request received!");

        return Enumerable.Range(1, 2)
			.Select(index => $"Alert {index} - Tornado Warning")
			.ToArray();
    }
}
