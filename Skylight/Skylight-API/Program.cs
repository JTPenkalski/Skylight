using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Skylight.DatabaseContexts.Factories;
using Skylight.Startup.Mappings;
using Skylight.Startup.Services;
using System;

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
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(CoreProfile));
            builder.Services.AddDbContextRepositoryServices();
            
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
            app.MapControllers();
            app.UseCors("SkylightOrigins");

            // Add development middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                if (app.Configuration.GetValue<bool>("UseTestDatabase"))
                {
                    using (IServiceScope scope = app.Services.CreateScope())
                    {
                        IWeatherExperienceContextFactory contextFactory = scope.ServiceProvider.GetRequiredService<IWeatherExperienceContextFactory>();
                        contextFactory.InitializeTestDatabase();
                    }
                }
            }

            // Start the web application
            app.Run();
        }
    }
}