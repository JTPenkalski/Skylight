namespace Skylight.Tests.Architecture.Domain;

public class DependencyTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Domain_ShouldNot_DependOnApplication()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Domain)
            .ShouldNot()
            .HaveDependencyOnAny(nameof(Application))
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Domain_ShouldNot_DependOnInfrastructure()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Domain)
            .ShouldNot()
            .HaveDependencyOnAny(nameof(Infrastructure), nameof(Data), nameof(Web))
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }
}
