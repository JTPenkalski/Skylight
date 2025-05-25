using Skylight.AppDefaults;
using Skylight.Application;
using Skylight.Application.Common.Identity;
using Skylight.Infrastructure;
using Skylight.Infrastructure.Identity.Users;
using Skylight.Infrastructure.MigrationWorker;

var builder = Host.CreateApplicationBuilder(args);
bool isProduction = builder.Environment.IsProduction();

builder
	.AddAppDefaults();

builder.Services
	.AddInfrastructure(builder.Configuration, isProduction)
	.AddApplication()
	.AddScoped<ICurrentUserService, SkylightSystemUserService>()
	.AddOpenTelemetry()
		.WithTracing(options => options.AddSource(Worker.ActivitySourceName));

builder.Services
	.AddHostedService<Worker>();

IHost host = builder.Build();

await host.RunAsync();
