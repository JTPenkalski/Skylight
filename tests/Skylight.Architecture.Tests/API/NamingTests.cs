﻿using Skylight.API.Hubs;
using Skylight.Infrastructure.Jobs;
using Skylight.Infrastructure.Jobs.Schedules;

namespace Skylight.Architecture.Tests.API;

public class NamingTests(ITestOutputHelper outputHelper)
{
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

	[Fact]
	public void Jobs_ShouldHaveJobSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.API)
			.That()
			.ImplementInterface(typeof(IJob))
			.Should()
			.HaveNameEndingWith("Job")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void JobSchedulers_ShouldHaveJobSchedulerSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.API)
			.That()
			.ImplementInterface(typeof(IJobScheduler))
			.Should()
			.HaveNameEndingWith("JobScheduler")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}

	[Fact]
	public void JobSchedulerOptions_ShouldHaveJobSchedulerOptionSuffix()
	{
		TestResult result = Types
			.InAssembly(Assemblies.Infrastructure)
			.That()
			.ImplementInterface(typeof(IJobSchedulerOptions))
			.Should()
			.HaveNameEndingWith("JobSchedulerOptions")
			.GetResult();

		TestOutputHelpers.PrintFailingTypes(outputHelper, result);

		Assert.True(result.IsSuccessful);
	}
}
