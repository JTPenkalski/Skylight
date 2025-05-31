using Skylight.API;
using Skylight.Application;
using Skylight.Infrastructure;
using Skylight.Infrastructure.Data;
using Skylight.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
bool isProduction = builder.Environment.IsProduction();

// Add Logging
builder.Logging
	.ClearProviders()
	.AddConsole()
	.Configure(options =>
	{
		// These flags are based on common distributed tracing concepts
		options.ActivityTrackingOptions =
			ActivityTrackingOptions.TraceId
			| ActivityTrackingOptions.SpanId;
	});

// Add Services
builder.AddServiceDefaults();

builder.Services
	.AddLogging()
	.AddHttpLogging(x =>
	{
		x.CombineLogs = true;
		x.RequestHeaders.Add("Origin");
		x.RequestHeaders.Add("Access-Control-Request-Headers");
		x.RequestHeaders.Add("Access-Control-Request-Method");
		x.ResponseHeaders.Add("Access-Control-Allow-Headers");
		x.ResponseHeaders.Add("Access-Control-Allow-Methods");
		x.ResponseHeaders.Add("Access-Control-Allow-Origin");
	})
	.AddOptions()
	.AddApplication()
	.AddInfrastructure(builder.Configuration, isProduction)
	.AddApi(builder.Configuration, isProduction);

// Enrich Services
builder
	.EnrichNpgsqlDbContext<SkylightDbContext>();

WebApplication application = builder.Build();

// Add Development Middleware
if (application.Environment.IsDevelopment())
{
	application
		.UseDevelopmentInfrastructure()
		.UseDevelopmentApi();
}

// Add Middleware
application
	.UseHttpsRedirection()
	.UseHttpLogging()
	.UseRouting()
	.UseCors()
	.UseAuthentication()
	.UseAuthorization()
	.UseRateLimiter()
	.UseBackgroundJobs();

// Add Development Route Mappings
if (application.Environment.IsDevelopment())
{
	application
		.MapDevelopmentApi();
}

// Add Route Mappings
application
	.MapDefaultEndpoints()
	.MapHubs()
	.MapControllers();

await application.RunAsync();
