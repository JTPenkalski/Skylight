var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);

var postgres = builder
	.AddPostgres("skylight-postgres", username, password)
	.AddDatabase("skylight-postgres-db");

var api = builder
	.AddProject<Projects.Skylight_API>("skylight-api")
	.WithReference(postgres)
	.WaitFor(postgres);

await builder.Build().RunAsync();
