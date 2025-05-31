using Mono.Cecil;

namespace Skylight.Architecture.Tests.Rules;

/// <summary>
/// Checks if all async methods on a type end with the "Async" suffix.
/// </summary>
public class AsyncMethodsHaveAsyncSuffixRule : ICustomRule
{
	public bool MeetsRule(TypeDefinition type)
	{
		IEnumerable<MethodDefinition> methodsWithoutAsyncSuffix = type.Methods
			.Where(x =>
				x.ReturnType.HasNameMatchingType<Task>()
				&& !x.Name.EndsWith("Async"))
			.ToList();

		return !methodsWithoutAsyncSuffix.Any();
	}
}
