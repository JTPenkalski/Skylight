using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Validators;

/// <summary>
/// Determines if a string is a valid NWS Zone ID.
/// </summary>
public partial class ZoneIdValidator<T> : PropertyValidator<T, string>
{
	public override string Name => "ZoneIdValidator";

	public override bool IsValid(ValidationContext<T> context, string value) =>
		ZoneIdRegex().Match(value).Success;

	protected override string GetDefaultMessageTemplate(string errorCode)
		=> "'{PropertyName}' must be a valid NWS Zone ID.";

	[GeneratedRegex(@"^(A[KLMNRSZ]|C[AOT]|D[CE]|F[LM]|G[AMU]|I[ADLN]|K[SY]|L[ACEHMOS]|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[AHKMRSWZ]|S[CDL]|T[NX]|UT|V[AIT]|W[AIVY]|[HR]I)[CZ]\d{3}$")]
	private static partial Regex ZoneIdRegex();
}

public static class ZoneIdValidatorExtensions
{
	/// <summary>
	/// Adds a <see cref="ZoneIdValidator{T}"/> to this property.
	/// </summary>
	public static IRuleBuilderOptions<T, string> IsZoneId<T>(this IRuleBuilder<T, string> ruleBuilder) =>
		ruleBuilder.SetValidator(new ZoneIdValidator<T>());
}
