using AutoMapper;
using Skylight.WebModels.Forms;
using Skylight.WebModels.Models;
using System.Linq;

namespace Skylight.Host.Mappings
{
    /// <summary>
    /// AutoMapper Profile for automatically converting between the Web API view models and the Service models.
    /// </summary>
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            MapCoreModels();
            MapFormModels();
        }

        /// <summary>
        /// Creates an AutoMapper mapping between Web Models and Core Models.
        /// </summary>
        private void MapCoreModels()
        {
            var typeMappings = from webModelType in typeof(BaseWebModel).Assembly.GetTypes()
                               where webModelType.Namespace == $"{nameof(Skylight)}.{nameof(Skylight.WebModels)}.{nameof(Skylight.WebModels.Models)}"
                               join coreModelType in typeof(Models.BaseModel).Assembly.GetTypes() on webModelType.Name equals coreModelType.Name
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

        /// <summary>
        /// Creates an AutoMapper mapping between Web Form Models and Core Form Models.
        /// </summary>
        /// <remarks>
        /// Does not map <see cref="Forms.FormControlValidation"/> or its components, since those are already designed to be exposed on the API.
        /// <br/>
        /// <see cref="Forms.FormGuide"/> and <see cref="Forms.FormControlGuide{T}"/> types are still mapped, since they use internal data models.
        /// </remarks>
        private void MapFormModels()
        {
            var typeMappings = from webModelType in typeof(FormGuide).Assembly.GetTypes()
                               where webModelType.Namespace == $"{nameof(Skylight)}.{nameof(Skylight.WebModels)}.{nameof(Skylight.WebModels.Forms)}"
                               join coreModelType in typeof(Forms.FormGuide).Assembly.GetTypes() on webModelType.Name equals coreModelType.Name
                               select new { Web = webModelType, Core = coreModelType };

            foreach (var typeMapping in typeMappings)
            {
                CreateMap(typeMapping.Core, typeMapping.Web);
            }

            // Context: Web -> Core
            CreateMap<FormGuideContext, Forms.FormGuideContext>();

            // Control Guides: Core -> Web
            CreateMap(typeof(Forms.FormControlGuide<>), typeof(FormControlGuide));
            CreateMap(typeof(Forms.FormControlValue<>), typeof(FormControlValue));
        }
    }
}