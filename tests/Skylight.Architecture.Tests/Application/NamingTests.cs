using Skylight.Application.Features.Interfaces;

namespace Skylight.Architecture.Tests.Application;

public class NamingTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void Handlers_ShouldHaveHandlerSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Application)
			.That()
			.ImplementInterface(typeof(ICommandHandler<>))
			.Or()
			.ImplementInterface(typeof(IQueryHandler<,>))
			.Should()
			.HaveNameEndingWith("Handler")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void Commands_ShouldHaveCommandSuffix()
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
	public void Queries_ShouldHaveQuerySuffix()
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
	public void Responses_ShouldHaveResponseSuffix()
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

	[Fact]
	public void Interfaces_ShouldHaveActionsWithAsyncSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Application)
			.That()
			.ResideInNamespaceContaining(nameof(Skylight.Application))
			.And()
			.AreInterfaces()
			.Should()
			.MeetCustomRule(new AsyncMethodsHaveAsyncSuffixRule())
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
