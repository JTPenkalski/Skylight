namespace Skylight.Tests.Architecture.Application;

public class DependencyTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Application_ShouldNot_DependOnInfrastructure()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .ShouldNot()
            .HaveDependencyOnAny(nameof(Infrastructure), nameof(Data), nameof(Web))
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }
}
