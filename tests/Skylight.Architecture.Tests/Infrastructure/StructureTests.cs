using Skylight.Infrastructure.Clients;

namespace Skylight.Architecture.Tests.Infrastructure;

public class StructureTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void ClientRequestsAndResponses_ShouldBeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IClientRequest))
			.Or()
			.ImplementInterface(typeof(IClientResponse))
			.Should()
			.BeSealed()
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
