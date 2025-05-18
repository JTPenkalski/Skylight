using Skylight.Domain.Common.Events;

namespace Skylight.Architecture.Tests.Domain;

public class NamingTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void DomainEvents_ShouldHaveEventSuffix()
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
	public void Exceptions_ShouldHaveExceptionSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Domain)
			.That()
			.Inherit(typeof(Exception))
			.Should()
			.MeetCustomRule(new TypeNameEndsWithAllowingGenericsRule("Exception"))
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
