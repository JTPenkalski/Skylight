using Skylight.Application;
using Skylight.Application.Configuration;
using Skylight.Data;
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

        // Add Configuration
        builder.Services
            .AddOptions()
            .Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.RootKey));
        
        // Add Application Services
        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddData(builder.Configuration)
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
        app.UseAuthorization();
        app.UseCors("SkylightOrigins");
        app.MapControllers();
        
        // Add Development Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentWeb();
            app.UseDevelopmentData(app.Configuration);
        }

        // Start the Web Application
        app.Run();
    }
}