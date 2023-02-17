using AutoMapper;
using System;
using System.Linq;

namespace Skylight.Mappings
{
    /// <summary>
    /// AutoMapper Profile for automatically converting between the Web API view models and the EF Core models.
    /// </summary>
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            var typeMappings = from webModelType in typeof(WebModels.BaseWebModel).Assembly.GetTypes()
                               where webModelType.Namespace == nameof(Skylight.WebModels)
                               join coreModelType in typeof(Models.BaseModel).Assembly.GetTypes() on webModelType.Name equals coreModelType.Name
                               select new { Web = webModelType, Core = coreModelType };

            foreach (var typeMapping in typeMappings)
            {
                Console.WriteLine($"Mapping {typeMapping.Web} -> {typeMapping.Core}");
                Console.WriteLine($"Mapping {typeMapping.Core} -> {typeMapping.Web}");

                CreateMap(typeMapping.Web, typeMapping.Core);
                CreateMap(typeMapping.Core, typeMapping.Web);
            }
        }
    }
}