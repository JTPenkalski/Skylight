using Scalar.AspNetCore;
using Skylight.API;
using Skylight.API.Controllers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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
	.AddApi();

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
