#pragma warning disable S1481

using Skylight.AppHost.Extensions;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

var postgressUsername = builder.AddParameter("pg-username", secret: true);
var postgressPassword = builder.AddParameter("pg-password", secret: true);
var postgres = builder
	.AddPostgres("skylight-postgres", postgressUsername, postgressPassword)
		.WithPgAdmin()
		.PublishAsConnectionString()
	.AddDatabase("skylight-postgres-db", "skylight");

var migrationWorker = builder
	.AddProject<Projects.Skylight_Worker_Migration>("skylight-worker-migration")
	.WithReference(postgres)
	.WaitFor(postgres);

var skylightApi = builder
	.AddProject<Projects.Skylight_API>("skylight-api")
		.WithReference(postgres)
		.WaitForCompletion(migrationWorker)
	.WithExternalHttpEndpoints();

var webUi = builder
	.AddNpmApp("skylight-webui", "../Skylight.WebUI", builder.Configuration["NODE_SCRIPT"] ?? "dev")
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
