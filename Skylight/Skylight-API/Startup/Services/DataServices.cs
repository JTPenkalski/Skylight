using Microsoft.Extensions.DependencyInjection;
using Skylight.Models;
using Skylight.Repositories;
using System.Linq;

namespace Skylight.Startup.Services
{
    /// <summary>
    /// Extension class for adding necessary setup for the data layer during bootstrapping.
    /// </summary>
    public static class DataServices
    {
        /// <summary>
        /// Adds the required dependency injection mappings to use services from the data layer.
        /// </summary>
        /// <returns>The service collection instance.</returns>
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            var dependencyMappings = from core in typeof(BaseModel).Assembly.ExportedTypes
                                     join data in typeof(BaseRepository<>).Assembly.ExportedTypes on core.Name[1..] equals data.Name
                                     where core.IsInterface && data.IsClass
                                     select new { Interface = core, Class = data };

            foreach (var mapping in dependencyMappings)
            {
                services.AddScoped(mapping.Interface, mapping.Class);
            }

            return services;
        }
    }
}