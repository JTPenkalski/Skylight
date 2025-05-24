using Skylight.Application.Features.Interfaces;

namespace Skylight.Architecture.Tests.Application;

public class StructureTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void CommandsAndQueries_ShouldBeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Application)
			.That()
			.ImplementInterface(typeof(ICommand))
			.Or()
			.ImplementInterface(typeof(IQuery<>))
			.Or()
			.AreNestedPublic()
			.Should()
			.BeSealed()
			.Or()
			.MeetCustomRule(new ParentTypeNameEndsWithRule("Handler"))
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
