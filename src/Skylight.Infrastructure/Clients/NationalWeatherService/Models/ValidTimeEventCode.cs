using System.Diagnostics.CodeAnalysis;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// The Valid Time Event Code (VTEC) of the subject alert message. 
/// </summary>
/// <remarks>
/// Of the form /K.AAA.CCCC.PP.S.####.yymmddThhnnZ‐yymmddThhnnZ/ where:
/// <code>
///		K = Product Class
///		AAA = Action
///		CCCC = Office ID
///		PP = Phenomena
///		S = Significance
///		#### = Event Tracking Number (ETN)
///		Date 1 = Event Beginning Date
///		Date 2 = Event Ending Date
/// </code>
/// </remarks>
public sealed record ValidTimeEventCode(
	string ProductClass,
	string Action,
	string OfficeId,
	string Phenomena,
	string Significance,
	string EventTrackingNumber,
	string EventBeginningDate,
	string EventEndingDate)
{
	public string EventCode => $"{Phenomena}{Significance}";

	[return: NotNullIfNotNull(nameof(value))]
	public static ValidTimeEventCode? Parse(string? value)
	{
		if (string.IsNullOrWhiteSpace(value)) return null;

		string productClass = value[1..2];
		string action = value[3..6];
		string officeId = value[7..11];
		string phenomena = value[12..14];
		string significance = value[15..16];
		string eventNumber = value[17..21];
		string beginTime = value[22..34];
		string endTime = value[35..47];

		return new(productClass, action, officeId, phenomena, significance, eventNumber, beginTime, endTime);
	}

	public override string ToString() =>
		$"/{ProductClass}.{Action}.{OfficeId}.{Phenomena}.{Significance}.{EventTrackingNumber}.{EventBeginningDate}-{EventEndingDate}/";
}
