namespace Skylight.Domain.Common.Extensions;

/// <summary>
/// Extension methods for dates and times.
/// </summary>
public static class DateTimeExtensions
{
	public static DateTimeOffset ToNextHour(this DateTimeOffset dateTimeOffset) =>
		new(dateTimeOffset.Year,
			dateTimeOffset.Month,
			dateTimeOffset.Day,
			dateTimeOffset.Hour + 1,
			0,
			0,
			dateTimeOffset.Offset);
}
