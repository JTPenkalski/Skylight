using System.Text.RegularExpressions;

namespace Skylight.Utilities.Extensions;

/// <summary>
/// Extension methods for strings.
/// </summary>
public static partial class StringExtensions
{
    [GeneratedRegex(@"^(-?[1-9]\d*|0)$")]
    private static partial Regex IntegerRegex();

    [GeneratedRegex(@"^(-?[1-9]\d*|0)(\.\d+)?$")]
    private static partial Regex NumberRegex();

    /// <summary>
    /// Tests the string against an integer Regex.
    /// </summary>
    /// <returns>True if the string is an integer, false otherwise.</returns>
    public static bool IsInteger(this string value) => IntegerRegex().IsMatch(value);

    /// <summary>
    /// Tests the string against a numeric Regex.
    /// </summary>
    /// <returns>True if the string is a number, false otherwise.</returns>
    public static bool IsNumber(this string value) => NumberRegex().IsMatch(value);
}