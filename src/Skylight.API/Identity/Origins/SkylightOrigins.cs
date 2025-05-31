namespace Skylight.API.Identity.Origins;

/// <summary>
/// Stores CORS information about the API.
/// </summary>
public static class SkylightOrigins
{
	public const string Anonymous = "anonymous";
	public const string Local = "localhost";

	public static readonly string[] Domains = ["https://skylight-weather.app", "https://www.skylight-weather.app"];
}
