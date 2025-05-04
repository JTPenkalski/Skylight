using System.Globalization;
using System.Text.RegularExpressions;

namespace Skylight.Domain.Common.Extensions;

/// <summary>
/// Extension methods for strings.
/// </summary>
public static partial class StringExtensions
{
	[GeneratedRegex(@"^(-?[1-9]\d*|0)$")]
	private static partial Regex IntegerRegex();

	[GeneratedRegex(@"^(-?[1-9]\d*|0)(\.\d+)?$")]
	private static partial Regex NumberRegex();

	private static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;

	/// <summary>
	/// Tests the string against an integer Regex.
	/// </summary>
	/// <returns>True if the string is an integer, false otherwise.</returns>
	public static bool IsInteger(this string value) =>
		IntegerRegex().IsMatch(value);

	/// <summary>
	/// Tests the string against a numeric Regex.
	/// </summary>
	/// <returns>True if the string is a number, false otherwise.</returns>
	public static bool IsNumber(this string value) =>
		NumberRegex().IsMatch(value);

	/// <summary>
	/// Capitalizes the first character of a string.
	/// </summary>
	/// <returns>The new string value.</returns>
	public static string CapitalizeFirst(this string value) =>
		string.Concat(value[0].ToString().ToUpper(), value.AsSpan(1));

	/// <summary>
	/// Converts a string to Title Case.
	/// </summary>
	/// <returns>The new string value.</returns>
	public static string ToTitleCase(this string value) =>
		TextInfo.ToTitleCase(value);
}
