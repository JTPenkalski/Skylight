﻿using System.Diagnostics.CodeAnalysis;
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

	[GeneratedRegex(@"[^0-9.-]")]
	private static partial Regex NonNumeric();

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
	/// Tests the string for null, whitespace, or zero values.
	/// </summary>
	/// <returns>True if the string meets any of these conditions, false otherwise.</returns>
	public static bool IsNullOrWhiteSpaceOrZero([NotNullWhen(true)] this string? value)
	{
		bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(value);
		bool isZero = float.TryParse(value, out float number)
			&& number > -float.Epsilon
			&& number < float.Epsilon;

		return isNullOrWhiteSpace || isZero;
	}

	/// <summary>
	/// Capitalizes the first character of a string.
	/// </summary>
	/// <returns>The new string value.</returns>
	public static string CapitalizeFirst(this string value) =>
		string.Concat(value[0].ToString().ToUpper(), value.AsSpan(1));

	/// <summary>
	/// Converts a string to its numeric representation, removing all non-numeric characters.
	/// </summary>
	/// <returns>The new string vbalue, with only numeric characters.</returns>
	public static string ToNumeric(this string value) =>
		NonNumeric().Replace(value, string.Empty);

	/// <summary>
	/// Converts a string to Title Case.
	/// </summary>
	/// <returns>The new string value.</returns>
	public static string ToTitleCase(this string value) =>
		TextInfo.ToTitleCase(value.ToLower());
}
