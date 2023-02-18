using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Skylight.Startup.Mappings
{
    /// <summary>
    /// AutoMapper Profile for automatically converting between the Web API view models and the EF Core models.
    /// </summary>
    public class CoreProfile : Profile
    {
        public CoreProfile(ILogger<CoreProfile> logger)
        {
            var typeMappings = from webModelType in typeof(WebModels.BaseWebModel).Assembly.GetTypes()
                               where webModelType.Namespace == nameof(WebModels)
                               join coreModelType in typeof(Models.BaseModel).Assembly.GetTypes() on webModelType.Name equals coreModelType.Name
                               select new { Web = webModelType, Core = coreModelType };

            foreach (var typeMapping in typeMappings)
            {
                logger.LogDebug($"Mapping {typeMapping.Web} -> {typeMapping.Core}");
                logger.LogDebug($"Mapping {typeMapping.Core} -> {typeMapping.Web}");

                CreateMap(typeMapping.Web, typeMapping.Core);
                CreateMap(typeMapping.Core, typeMapping.Web);
            }
        }
    }
}