using Skylight.Infrastructure.Clients;
using Skylight.Infrastructure.Jobs;

namespace Skylight.Tests.Architecture.Infrastructure;

public class StructureTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void ClientModels_Should_BeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ResideInNamespaceContaining(nameof(Skylight.Infrastructure.Clients))
			.And()
			.ResideInNamespaceEndingWith("Models")
			.And()
			.AreNotAbstract()
			.And()
			.DoNotHaveNameEndingWith("Validator")
			.Should()
			.BeSealed()
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void ClientRequestsAndResponses_Should_BeSealed()
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
	public void Jobs_Should_BeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IJob))
			.Should()
			.BeSealed()
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void JobRequests_Should_BeSealed()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ResideInNamespaceContaining(nameof(Skylight.Infrastructure.Hubs))
			.And()
			.ResideInNamespaceEndingWith("Requests")
			.And()
			.AreNotAbstract()
			.And()
			.DoNotHaveNameEndingWith("Validator")
			.Should()
			.BeSealed()
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
