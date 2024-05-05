using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Skylight.Application;
using Skylight.Application.Configuration;
using Skylight.Application.Interfaces.Data;
using Skylight.Controllers;
using Skylight.Data;
using Skylight.Host.Services.ConfigureOptions;
using System.Reflection;
using System.Text.Json.Serialization;

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
                    options.DefaultApiVersion = new ApiVersion(SkylightApiVersion.MAJOR, SkylightApiVersion.MINOR);
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
                .AddApplication()
                .AddData(builder.Configuration.GetConnectionString("Default"));

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
                    using IServiceScope scope = app.Services.CreateScope();

                     scope.ServiceProvider
                        .GetRequiredService<ISkylightContextInitializer>()
                        .InitializeAsync()
                        .GetAwaiter()
                        .GetResult();
                }
            }

            // Start the Web Application
            app.Run();
        }
    }
}