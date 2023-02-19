using Microsoft.Extensions.DependencyInjection;
using Skylight.Models;
using Skylight.Repositories;
using System.Linq;

namespace Skylight.Startup.Services
{
    public static class DataServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            var dependencyMappings = from core in typeof(BaseModel).Assembly.ExportedTypes
                                     join data in typeof(BaseRepository).Assembly.ExportedTypes on core.Name[1..] equals data.Name
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