var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Skylight_API>("skylight-api");

await builder.Build().RunAsync();
