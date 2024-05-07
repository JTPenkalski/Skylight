using AutoMapper;
using Skylight.Web.Models;
using Core = Skylight.Domain.Entities;

namespace Skylight.Models.Mappings;

/// <summary>
/// AutoMapper Profile for automatically converting between Web API models and Domain entities.
/// </summary>
public class DomainProfile : Profile
{
    public DomainProfile()
    {
        MapCoreModels();
    }

    /// <summary>
    /// Creates an AutoMapper mapping between Web Models and Core Models.
    /// </summary>
    private void MapCoreModels()
    {
        var typeMappings = from webModelType in typeof(BaseModel).Assembly.GetTypes()
                           where webModelType.Namespace == $"{nameof(Skylight)}.{nameof(Web)}.{nameof(Web.Models)}"
                           join coreModelType in typeof(Core.BaseEntity).Assembly.GetTypes() on webModelType.Name equals coreModelType.Name
                           select new { Web = webModelType, Core = coreModelType };

        foreach (var typeMapping in typeMappings)
        {
            CreateMap(typeMapping.Web, typeMapping.Core);
            CreateMap(typeMapping.Core, typeMapping.Web);

            // When converting Core model properties to object properties within a Web model,
            // convert them to Web models and store them in the object properties
            CreateMap(typeMapping.Core, typeof(object)).As(typeMapping.Web);
        }
    }
}