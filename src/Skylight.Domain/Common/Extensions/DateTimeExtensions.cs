namespace Skylight.Domain.Common.Extensions;

/// <summary>
/// Extension methods for dates and times.
/// </summary>
public static class DateTimeExtensions
{
	/// <summary>
	/// Clamps <paramref name="value"/> between <paramref name="min"/> and <paramref name="max"/>.
	/// </summary>
	/// <param name="min">The lower bound.</param>
	/// <param name="max">The upper bound.</param>
	/// <returns>The clamped <see cref="DateTimeOffset"/> value.</returns>
	public static DateTimeOffset Clamp(this DateTimeOffset value, DateTimeOffset min, DateTimeOffset max)
	{
		if (value < min)
		{
			return min;
		}
		else if (value > max)
		{
			return max;
		}

		return value;
	}

	/// <summary>
	/// Rounds <paramref name="value"/> up to the next full hour, discarding minutes/seconds.
	/// </summary>
	/// <returns>A new <see cref="DateTimeOffset"/> at the next full hour.</returns>
	public static DateTimeOffset ToNextHour(this DateTimeOffset value) =>
		new(value.Year,
			value.Month,
			value.Day,
			value.Hour + 1,
			0,
			0,
			value.Offset);
}
