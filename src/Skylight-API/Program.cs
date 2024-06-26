using Skylight.Application;
using Skylight.Controllers;
using Skylight.Data;
using Skylight.Domain.Entities;
using Skylight.Domain.Events;
using Skylight.Infrastructure;
using Skylight.Web;

namespace Skylight;

/// <summary>
/// Contains the bootstrapping code for the Skylight API.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // Create the Web Application Builder
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

		// Add Application Services
		bool isProduction = builder.Environment.IsProduction();

		builder.Services
			.AddLogging()
			.AddOptions()
            .AddApplication()
            .AddInfrastructure(builder.Configuration)
            .AddData(builder.Configuration, isProduction)
            .AddWeb(isProduction);
        
        // Build the Web Application
        WebApplication app = builder.Build();

		// Add Middleware
        app.UseHttpsRedirection();
        app.UseCors(SkylightOrigins.LocalHostPolicy);
		app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
        
        // Add Development Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentWeb();
            app.UseDevelopmentData();
			app.UseDevelopmentInfrastructure();
        }

		// Add Jobs
		app.UseBackgroundJobs();

		// Add Hubs
		app.MapHubs();

		// Start the Web Application
		app.Run();
    }
}
