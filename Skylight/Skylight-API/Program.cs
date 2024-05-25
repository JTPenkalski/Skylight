using Skylight.Application;
using Skylight.Application.Configuration;
using Skylight.Controllers;
using Skylight.Data;
using Skylight.Infrastructure;
using Skylight.Infrastructure.Configuration;
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

        // Add Configuration
        builder.Services
            .AddOptions();
        
        // Add Application Services
        builder.Services
            .AddApplication(builder.Configuration)
            .AddInfrastructure(builder.Configuration)
            .AddData(builder.Configuration, builder.Environment.IsProduction())
            .AddWeb();

        // Add Development Services
        if (builder.Environment.IsDevelopment())
        {
            builder.Services
                .AddDevelopmentWeb();
        }
        
        // Build the Web Application
        WebApplication app = builder.Build();
        
        // Add Middleware
        app.UseHttpsRedirection();
        app.UseCors(SkylightOrigins.LocalHostPolicy);
        app.UseAuthorization();
        
        app.MapControllers();
        
        // Add Development Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentWeb();
            app.UseDevelopmentData();
        }

        // Start the Web Application
        app.Run();
    }
}