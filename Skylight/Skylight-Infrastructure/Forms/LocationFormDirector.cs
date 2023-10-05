using Skylight.Forms.Directors;
using Skylight.Forms.Guides;
using Skylight.Models;
using Skylight.Repositories;
using System.Threading.Tasks;

namespace Skylight.Forms
{
    /// <inheritdoc cref=" IWeatherEventFormDirector"/>
    public class LocationFormDirector : BaseFormDirector<Location, LocationFormGuide>, ILocationFormDirector
    {
        /// <inheritdoc cref="BaseFormDirector{T}(IUnitOfWork)"/>
        public LocationFormDirector(
            IUnitOfWork unitOfWork
        ) : base(unitOfWork) { }

        public override Task<LocationFormGuide> GetGuideAsync(Location model, FormGuideContext context) =>
            Task.FromResult(
                new LocationFormGuide
                {
                    City = GetCityFormGuide(model),
                    Country = GetCountryFormGuide(model)
                }
            );

        protected virtual FormControlGuide<string> GetCityFormGuide(Location model) =>
            new()
            {
                Validation = FormControlValidators.Required
            };

        protected virtual FormControlGuide<string> GetCountryFormGuide(Location model) =>
            new()
            {
                Validation = FormControlValidators.Required
            };

    }
}
