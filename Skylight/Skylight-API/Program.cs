using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Skylight.Mappings;

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
            builder.Services.AddAutoMapper(typeof(CoreProfile));
            
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
            }

            // Start the web application
            app.Run();
        }
    }
}