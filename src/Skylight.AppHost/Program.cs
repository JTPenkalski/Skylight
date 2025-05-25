#pragma warning disable S1481

using Skylight.AppHost.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
	.AddPostgres("skylight-postgres")
	.WithPgAdmin()
	.AddDatabase("skylight-postgres-db");

var skylightApi = builder
	.AddProject<Projects.Skylight_API>("skylight-api")
	.WithReference(postgres)
	.WaitFor(postgres);

var webUi = builder
	.AddNpmApp("skylight-webui", "../Skylight.WebUI", "dev")
	.WithReference(skylightApi)
	.WaitFor(skylightApi)
	.WithHttpEndpoint(env: "PORT")
	.WithEnvironment("NUXT_PUBLIC_API_BASE_SKYLIGHT", skylightApi.GetEndpoint("https"))
	.WithExternalHttpEndpoints()
	.PublishAsDockerFile();

builder.Eventing.Subscribe<AfterEndpointsAllocatedEvent>(
	(@event, cancellationToken) =>
	{
		skylightApi
			.WithBrowserCommand(
				name: "scalar",
				displayName: "Scalar UI",
				url: $"{skylightApi.GetEndpoint("https").Url}/scalar")
			.WithBrowserCommand(
				name: "hangfire",
				displayName: "Hangfire UI",
				url: $"{skylightApi.GetEndpoint("https").Url}/jobs");

		return Task.CompletedTask;
	});

await builder.Build().RunAsync();

#pragma warning restore S1481
