using Microsoft.Extensions.DependencyInjection;
using Skylight.Models;
using Skylight.Services;
using System.Linq;

namespace Skylight.Startup.Services
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var dependencyMappings = from core in typeof(BaseModel).Assembly.ExportedTypes
                                     join infrastructure in typeof(BaseService).Assembly.ExportedTypes on core.Name[1..] equals infrastructure.Name
                                     where core.IsInterface && infrastructure.IsClass
                                     select new { Interface = core, Class = infrastructure };

            foreach (var mapping in dependencyMappings)
            {
                services.AddScoped(mapping.Interface, mapping.Class);
            }

            return services;
        }
    }
}