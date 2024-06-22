using Mono.Cecil;

namespace Skylight.Tests.Architecture.CustomRules;

/// <summary>
/// Checks if all async methods on a type end with the "Async" suffix.
/// </summary>
internal class AsyncMethodsHaveAsyncSuffixRule : ICustomRule
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
