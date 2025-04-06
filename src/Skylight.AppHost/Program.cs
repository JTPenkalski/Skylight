var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);

var postgress = builder
	.AddPostgres("skylight-postgress", username, password)
	.AddDatabase("skylight-postgress-db");

var api = builder
	.AddProject<Projects.Skylight_API>("skylight-api")
	.WithReference(postgress)
	.WaitFor(postgress);

await builder.Build().RunAsync();
