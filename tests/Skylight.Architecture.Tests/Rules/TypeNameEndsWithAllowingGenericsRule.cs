using Mono.Cecil;
using System.Text.RegularExpressions;

namespace Skylight.Architecture.Tests.Rules;

/// <summary>
/// Checks if a type name ends with the proper suffix, accounting for generic types.
/// </summary>
public class TypeNameEndsWithAllowingGenericsRule(string ending) : ICustomRule
{
	public bool MeetsRule(TypeDefinition type) =>
		Regex.IsMatch(type.Name, $@".*{ending}(`\d)?");
}
