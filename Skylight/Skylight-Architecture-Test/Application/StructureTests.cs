using Skylight.Application.Interfaces.Application;

namespace Skylight.Tests.Architecture.Application;

public class StructureTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void CommandsAndQueries_Should_BeSealed()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Or()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .BeSealed()
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void ClientModels_Should_BeSealed()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ResideInNamespaceContaining(nameof(Skylight.Application.Interfaces.Infrastructure.Clients))
            .And()
            .AreNotAbstract()
            .Should()
            .BeSealed()
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }
}
