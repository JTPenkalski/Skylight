using Skylight.Infrastructure.Jobs;

namespace Skylight.Architecture.Tests.API;

public class StructureTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void Jobs_Should_BeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.API)
			.That()
			.ImplementInterface(typeof(IJob))
			.Should()
			.BeSealed()
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
