using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Skylight.Application.Features.Alerts.Validators;

/// <summary>
/// Determines if a string is a valid Specific Area Message Encoding (SAME) Event Code.
/// </summary>
public partial class SameEventCodeValidator<T> : PropertyValidator<T, string>
{
	public override string Name => "SameEventCodeValidator";

	public override bool IsValid(ValidationContext<T> context, string value) =>
		SameEventCodeRegex().Match(value).Success;

	protected override string GetDefaultMessageTemplate(string errorCode) =>
		"'{PropertyName}' must be a valid SAME Event Code.";

	[GeneratedRegex(@"^[A-Z]{3}$")]
	private static partial Regex SameEventCodeRegex();
}

public static class SameEventCodeValidatorExtensions
{
	/// <summary>
	/// Adds a <see cref="SameEventCodeValidator{T}"/> to this property.
	/// </summary>
	public static IRuleBuilderOptions<T, string> IsSameEventCode<T>(this IRuleBuilder<T, string> ruleBuilder) =>
		ruleBuilder.SetValidator(new SameEventCodeValidator<T>());
}
