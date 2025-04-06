using Scalar.AspNetCore;
using Skylight.API;
using Skylight.API.Controllers;
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
	.AddOptions()
	.AddApplication()
	.AddInfrastructure(builder.Configuration, isProduction)
	.AddApi();

// Enrich Services
builder
	.EnrichNpgsqlDbContext<SkylightDbContext>();

WebApplication application = builder.Build();

// Add Route Mappings
application
	.MapDefaultEndpoints()
	.MapControllers();

// Add Development Registrations
if (application.Environment.IsDevelopment())
{
    application.MapOpenApi();
	application.MapScalarApiReference(options =>
	{
		options
			.WithTitle("Skylight API")
			.WithTheme(ScalarTheme.Purple)
			.AddDocuments($"v{SkylightApiVersion.Current}");
	});
}

// Add Middleware
application.UseHttpsRedirection();
application.UseAuthorization();

await application.RunAsync();
