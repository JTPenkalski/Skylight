using System.Reflection;

namespace Skylight.Tests.Architecture.Utilities;

/// <summary>
/// Utilities for outputting test failures to the output.
/// </summary>
internal static class TestOutputHelpers
{
    /// <summary>
    /// Prints a message to the Test Explorer output with failure information.
    /// </summary>
    /// <param name="outputHelper">The output stream.</param>
    /// <param name="result">The test result.</param>
    internal static void PrintFailingTypes(ITestOutputHelper outputHelper, TestResult result)
    {
        if (result.IsSuccessful) return;

        outputHelper.WriteLine("Types with failing conventions:");

        foreach (string failure in result.FailingTypeNames)
        {
            outputHelper.WriteLine($"\t- {failure}");
        }
    }

    /// <summary>
    /// Prints a message to the Test Explorer output with failure information.
    /// </summary>
    /// <param name="outputHelper">The output stream.</param>
    /// <param name="resultTypes">The test results.</param>
    internal static void PrintFailingTypes(ITestOutputHelper outputHelper, IEnumerable<Type> resultTypes)
    {
        outputHelper.WriteLine("Types with failing conventions:");

        foreach (Type failure in resultTypes)
        {
            outputHelper.WriteLine($"\t- {failure.FullName}");
        }
    }

    /// <summary>
    /// Prints a message to the Test Explorer output with failure information.
    /// </summary>
    /// <param name="outputHelper">The output stream.</param>
    /// <param name="resultMembers">The test results.</param>
    internal static void PrintFailingMembers(ITestOutputHelper outputHelper, IEnumerable<MemberInfo> resultMembers)
    {
        outputHelper.WriteLine("Members with failing conventions:");

        foreach (MemberInfo failure in resultMembers)
        {
            outputHelper.WriteLine($"\t- {failure.DeclaringType!.FullName}.{failure.Name}");
        }
    }
}
