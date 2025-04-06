var builder = DistributedApplication.CreateBuilder(args);

var postgress = builder
	.AddPostgres("skylight-postgress")
	.AddDatabase("skylight-postgress-db");

var api = builder
	.AddProject<Projects.Skylight_API>("skylight-api")
	.WithReference(postgress)
	.WaitFor(postgress);

await builder.Build().RunAsync();
