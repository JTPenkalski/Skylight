using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Skylight.Controllers;
using Skylight.Startup.Services;
using Skylight.Startup.Services.Options;
using Skylight.Contexts.Initializers;
using System.Reflection;
using Skylight.Contexts;
using Microsoft.EntityFrameworkCore;
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
            // Create the web application builder
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add logging
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
            
            // Add MVC services
            builder.Services
                .AddControllers()
                .AddJsonOptions(options => 
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                );

            // Add Versioning services
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

            // Add General services
            builder.Services
                .AddSwaggerGen()
                .AddDbContext<WeatherExperienceContext>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL_Server"));
                })
                .AddAutoMapper(Assembly.GetEntryAssembly())
                .AddInfrastructureServices()
                .AddDataServices();

            // Configure services
            builder.Services
                .ConfigureOptions<ConfigureSwaggerOptions>();

            // Add development services
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(options => options.AddPolicy
                (
                    "SkylightOrigins",
                    (policy) => policy.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader()
                ));
            }
            
            // Build the web application
            WebApplication app = builder.Build();

            // Add middleware
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("SkylightOrigins");
            app.MapControllers();

            // Add development middleware
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

                // Use test database rather than Migrations API
                if (app.Configuration.GetValue<bool>("UseTestDatabase"))
                {
                    using (IServiceScope scope = app.Services.CreateScope())
                    {
                        scope.ServiceProvider
                            .GetRequiredService<IWeatherExperienceContextInitializer>()
                            .Initialize();
                    }
                }
            }

            // Start the web application
            app.Run();
        }
    }
}