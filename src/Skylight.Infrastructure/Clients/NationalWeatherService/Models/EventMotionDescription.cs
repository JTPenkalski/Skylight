using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// The position and motion of a hazardous event given in local time.
/// </summary>
/// <remarks>
/// Of the form YYYY-MM-DDThh:mm:ssXzh:zm...event...dirDEG...spKT...lat,lon [, lat,lon...] where:
/// <code>
///		YYYY = Year
///		MM = Month(01-12)
///		DD = Day, 2 digits with leading zeros(01-31)
///		T marks the start of the time section
///		hh = 24-hour format of an hour with leading zeros(00-23)
///		mm = Minutes with leading zeros(00-59)
///		ss = Seconds, with leading zeros(00-59)
///		X = The symbol "+" if the preceding date and time are in a time zone ahead of UTC, or the symbol "-" if the preceding date and time are in a time zone behind UTC.If the time is in UTC, the symbol "-" will be used.
///		zh = Hours of offset from the preceding date and time to UTC, or "00" if the preceding time is in UTC
///		zm = Minutes of offset from the preceding date and time to UTC, or "00" if the preceding time is in UTC
///		event = storm
///		dir = three-digit direction from which the storm is moving, in degrees from 000 to 359 nonzero direction
///		sp = speed of movement of the storm, in knots from 0 to 99 without a leading zero
///		lat,lon = coded pair(s) identifying the latitude and longitude of the storm center expressed as a single point (in the case of one pair) or a line (if more than one pair is used) using WGS 84
/// </code>
/// </remarks>
public sealed record EventMotionDescription(DateTimeOffset Time, string Event, string Degrees, string Speed, string LatLon)
{
	[return: NotNullIfNotNull(nameof(value))]
	public static EventMotionDescription? Parse(string? value)
	{
		if (string.IsNullOrWhiteSpace(value)) return null;

		DateTimeFormatInfo timeFormat = new CultureInfo("en-US").DateTimeFormat;

		DateTimeOffset time = DateTimeOffset.Parse(value[0..24], timeFormat);
		string @event = value[28..33];
		string degrees = value[36..42];
		string speed = value[45..49];
		string latlon = value[52..];

		return new(time, @event, degrees, speed, latlon);
	}

	public override string ToString() =>
		$"{Time:O}...{Event}...{Degrees}...{Speed}...{LatLon}";
}
