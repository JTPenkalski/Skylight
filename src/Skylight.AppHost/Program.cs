using Skylight.AppHost.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);

var postgres = builder
	.AddPostgres("skylight-postgres", username, password, 22222)
	.AddDatabase("skylight-postgres-db");

var skylightApi = builder
	.AddProject<Projects.Skylight_API>("skylight-api")
	.WithReference(postgres)
	.WaitFor(postgres);

builder.Eventing.Subscribe<AfterEndpointsAllocatedEvent>(
	(@event, cancellationToken) =>
	{
		skylightApi
			.WithBrowserCommand(
				name: "scalar",
				displayName: "Scalar UI",
				url: $"{skylightApi.GetEndpoint("https").Url}/scalar");

		return Task.CompletedTask;
	});

await builder.Build().RunAsync();
