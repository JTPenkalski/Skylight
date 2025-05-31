using Mono.Cecil;

namespace Skylight.Architecture.Tests.Rules;

public class ParentTypeNameEndsWithRule(string ending) : ICustomRule
{
	public bool MeetsRule(TypeDefinition type) =>
		type.DeclaringType?.Name.EndsWith(ending) ?? false;
}
