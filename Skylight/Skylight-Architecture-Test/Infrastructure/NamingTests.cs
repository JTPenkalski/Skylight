using Skylight.Infrastructure.Clients;

namespace Skylight.Tests.Architecture.Infrastructure;

public class NamingTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void ClientRequests_Should_HaveRequestSuffix()
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
	public void ClientResponses_Should_HaveResponseSuffix()
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
}
