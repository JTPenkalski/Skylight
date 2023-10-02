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
            }
        }

        /// <summary>
        /// Creates an AutoMapper mapping between Web Form Models and Core Form Models.
        /// </summary>
        /// <remarks>
        /// Does not map <see cref="Forms.FormControlValidation"/> or its components, since those are already designed to be exposed on the API.
        /// <br/>
        /// <see cref="Forms.FormGuide"/> and <see cref="Forms.FormControl{T}"/> types are still mapped, since they use internal data models.
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

            CreateMap<FormGuideContext, Forms.FormGuideContext>();
            CreateMap(typeof(FormControl<>), typeof(Forms.FormControl<>));
            CreateMap(typeof(FormControlValue<>), typeof(Forms.FormControlValue<>));
        }
    }
}