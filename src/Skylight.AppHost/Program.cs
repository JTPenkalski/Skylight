using Skylight.AppHost.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);

var postgres = builder
	.AddPostgres("skylight-postgres", username, password)
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
