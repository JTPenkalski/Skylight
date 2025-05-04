namespace Skylight.Architecture.Tests.Domain;

public class DependencyTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void Domain_ShouldNotDependOnApplication()
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
	public void Domain_ShouldNotDependOnInfrastructure()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Domain)
			.ShouldNot()
			.HaveDependencyOnAny(nameof(Infrastructure), nameof(API))
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
