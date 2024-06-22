namespace Skylight.Tests.Architecture.CustomRules;

/// <summary>
/// Singleton instances of all Custom Rules.
/// </summary>
internal static class Rules
{
    internal static readonly AsyncMethodsHaveAsyncSuffixRule AsyncMethodsHaveAsyncSuffix = new();
}
