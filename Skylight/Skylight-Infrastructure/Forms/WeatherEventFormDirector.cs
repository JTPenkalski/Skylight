using Skylight.Extensions;
using Skylight.Models;
using Skylight.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Forms
{
    /// <inheritdoc cref=" IWeatherEventFormDirector"/>
    public class WeatherEventFormDirector : BaseFormDirector<WeatherEvent>, IWeatherEventFormDirector
    {
        /// <inheritdoc cref="BaseFormDirector{T}(IUnitOfWork)"/>
        public WeatherEventFormDirector(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public override async Task<IEnumerable<FormGuide>> GetGuide(WeatherEvent model)
        {
            var guide = new List<FormGuide>
            {
                GetNameFormGuide(model),
                await GetWeatherFormGuide(model)
            };

            guide.AddRange(await GetWeatherEventStatisticsGuides(model));

            return guide;
        }

        protected virtual FormGuide GetNameFormGuide(WeatherEvent model) =>
            new InputFormGuide("name")
            {
                Required = true
            };

        protected virtual async Task<FormGuide> GetWeatherFormGuide(WeatherEvent model) =>
            new SelectFormGuide<Weather>("weather")
            {
                Required = true,
                Options = (await unitOfWork.Weather.ReadAllAsync()).Select(x => new SelectOption<Weather>(x.Name, x))
            };

        protected virtual async Task<IEnumerable<FormGuide>> GetWeatherEventStatisticsGuides(WeatherEvent model) =>
            new List<FormGuide>
            {
                new SelectFormGuide<int>("statistics.efRating")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Tornado")),
                    Options = new List<SelectOption<int>>
                    {
                        new("EF-U", -1),
                        new("EF-0", 0),
                        new("EF-1", 1),
                        new("EF-2", 2),
                        new("EF-3", 3),
                        new("EF-4", 4),
                        new("EF-5", 5)
                    }
                },
                new InputFormGuide("statistics.pathDistance")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Tornado")),
                    MinValue = 0,
                    MaxValue = int.MaxValue,
                    Regex = InputFormGuide.IntegerRegex()
                },
                new InputFormGuide("statistics.funnelWidth")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Tornado")),
                    MinValue = 0,
                    MaxValue = int.MaxValue,
                    Regex = InputFormGuide.IntegerRegex()
                },
                new SelectFormGuide<int>("statistics.saffirSimpsonRating")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    Options = new List<SelectOption<int>>
                    {
                        new("Category 1", 1),
                        new("Category 2", 2),
                        new("Category 3", 3),
                        new("Category 4", 4),
                        new("Category 5", 5)
                    }
                },
                new InputFormGuide("statistics.lowestPressure")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    MinValue = 0,
                    MaxValue = int.MaxValue,
                    Regex = InputFormGuide.NumberRegex()
                },
                new InputFormGuide("statistics.maxWindSpeed")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    MinValue = 0,
                    MaxValue = int.MaxValue,
                    Regex = InputFormGuide.IntegerRegex()
                },
                new InputFormGuide("statistics.richterMagnitude")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    MinValue = 0,
                    MaxValue = int.MaxValue,
                    Regex = InputFormGuide.NumberRegex()
                },
                new SelectFormGuide<int>("statistics.mercalliIntensity")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    Options = new List<SelectOption<int>>
                    {
                        new("I - Not Felt", 1),
                        new("II - Weak", 2),
                        new("III - Weak", 3),
                        new("IV - Light", 4),
                        new("V - Moderate", 5),
                        new("VI - Strong", 6),
                        new("VII - Very Strong", 7),
                        new("VIII - Severe", 8),
                        new("IX - Violent", 9),
                        new("X - Extreme", 10)
                    }
                },
                new InputFormGuide("statistics.aftershocks")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    MinValue = 0,
                    MaxValue = int.MaxValue,
                    Regex = InputFormGuide.IntegerRegex()
                },
                new InputFormGuide("statistics.fault")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                },
                new FormGuide("statistics.relatedTsunami")
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                }
            };
    }
}
