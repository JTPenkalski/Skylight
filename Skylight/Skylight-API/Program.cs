using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Skylight.Contexts.Initializers;
using Skylight.Controllers;
using Skylight.Host.Services.ConfigureOptions;
using System.Text.Json.Serialization;
using System.Reflection;
using Skylight.Configuration.Options;
using Skylight.Host.Services.DependencyInjection;

namespace Skylight
{
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

            // Add MVC Services
            builder.Services
                .AddControllers()
                .AddJsonOptions(options => 
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                );

            // Add Versioning Services
            builder.Services
                .AddApiVersioning(options =>
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(Version.MAJOR, Version.MINOR);
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    // Specify group name for versions as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            // Add General Services
            builder.Services
                .AddSwaggerGen()
                .AddAutoMapper(Assembly.GetEntryAssembly())
                .AddInfrastructureServices()
                .AddDataServices()
                .AddDatabase(builder.Configuration.GetConnectionString("Default"));

            // Configure Services
            builder.Services
                .ConfigureOptions<ConfigureSwaggerOptions>();

            // Add Development Services
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(options => options.AddPolicy(
                    "SkylightOrigins",
                    policy => policy.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader()
                ));
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
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // Serve the Swagger UI by default at root URL
                    options.RoutePrefix = string.Empty;

                    // Create JSON endpoints for all API versions
                    foreach (ApiVersionDescription description in app.DescribeApiVersions())
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
                    }
                });

                if (app.Configuration.GetSection(DatabaseOptions.RootKey).Get<DatabaseOptions>()?.UseCreateAndDropMigrations ?? false)
                {
                    using (IServiceScope scope = app.Services.CreateScope())
                    {
                        scope.ServiceProvider
                            .GetRequiredService<IWeatherExperienceContextInitializer>()
                            .Initialize();
                    }
                }
            }

            // Start the Web Application
            app.Run();
        }
    }
}