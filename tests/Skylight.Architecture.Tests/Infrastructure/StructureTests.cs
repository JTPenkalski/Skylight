using Skylight.Infrastructure.Clients;
using Skylight.Infrastructure.Hubs;

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

	[Fact]
	public void HubInputsAndOutputs_ShouldBeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IHubInput))
			.Or()
			.ImplementInterface(typeof(IHubOutput))
			.Should()
			.BeSealed()
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
