using Skylight.Domain.Events;

namespace Skylight.Tests.Architecture.Domain;

public class NamingTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void DomainEvents_Should_HaveDomainEventSuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Domain)
            .That()
            .Inherit(typeof(DomainEvent))
            .Should()
            .HaveNameEndingWith("Event")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Exceptions_Should_HaveExceptionSuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Domain)
            .That()
            .Inherit(typeof(Exception))
            .Should()
            .HaveNameEndingWith("Exception")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }
}
