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
            .HaveNameEndingWith("DomainEvent")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }
}
