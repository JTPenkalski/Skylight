using Skylight.Infrastructure.Clients;
using Skylight.Infrastructure.Hubs;

namespace Skylight.Architecture.Tests.Infrastructure;

public class NamingTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void ClientRequests_ShouldHaveRequestSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IClientRequest))
			.Should()
			.HaveNameEndingWith("Request")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void ClientResponses_ShouldHaveResponseSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IClientResponse))
			.Should()
			.HaveNameEndingWith("Response")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void HubInputs_ShouldHaveInputSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IHubInput))
			.Should()
			.HaveNameEndingWith("Input")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void HubOutputs_ShouldHaveOutputSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IHubOutput))
			.Should()
			.HaveNameEndingWith("Output")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
