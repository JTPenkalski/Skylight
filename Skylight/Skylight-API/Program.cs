using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Skylight.Contexts;

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
            
            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            AddDbContextProviders(builder);
            
            // Add service development settings
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

            // Add middleware development settings
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // TODO: Delete after initial setup. Used for early development prototyping.
                using (IServiceScope scope = app.Services.CreateScope())
                {
                    WeatherExperienceContext context = scope.ServiceProvider.GetRequiredService<WeatherExperienceContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    WeatherExperienceContextInitializer.Initialize(context);
                }
            }

            // Start the web application
            app.Run();
        }

        /// <summary>
        /// Adds the required EF Core Database Contexts based on the executing environment. 
        /// </summary>
        /// <param name="builder">The builder used to generate the host.</param>
        private static void AddDbContextProviders(WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("SQL_Server");

            if (connectionString is not null)
            {
                if (builder.Environment.IsDevelopment())
                {
                    // Migrated to SQL Server for local development since the MySQL connector appeared to throw errors after the .NET 7 upgrade.
                    builder.Services.AddDbContext<WeatherExperienceContext>(options => options.UseSqlServer(connectionString));
                }
                else
                {
                    builder.Services.AddDbContext<WeatherExperienceContext>(options => options.UseSqlServer(connectionString));
                }
            }
        }
    }
}