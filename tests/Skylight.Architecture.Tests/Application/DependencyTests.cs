namespace Skylight.Architecture.Tests.Application;

public class DependencyTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void Application_ShouldNotDependOnInfrastructure()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Application)
			.ShouldNot()
			.HaveDependencyOnAny(nameof(Infrastructure), nameof(API))
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
