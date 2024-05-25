using Skylight.Application.Interfaces.Application;

namespace Skylight.Tests.Architecture.Application;

public class NamingTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void CommandHandlers_Should_HaveCommandHandlerSuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Commands_Should_HaveCommandSuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Queries_Should_HaveQuerySuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void QueryHandlers_Should_HaveQueryHandlerSuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Responses_Should_HaveResponseSuffix()
    {
        TestResult result = Types
            .InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(IResponse))
            .Should()
            .HaveNameEndingWith("Response")
            .GetResult();

        TestOutputHelpers.PrintFailingTypes(outputHelper, result);

        Assert.True(result.IsSuccessful);
    }
}
