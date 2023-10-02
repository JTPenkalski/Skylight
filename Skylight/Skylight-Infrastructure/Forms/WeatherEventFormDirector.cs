using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Skylight.Extensions;
using Skylight.Forms.Guides;
using Skylight.Models;
using Skylight.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Forms.Directors
{
    /// <inheritdoc cref=" IWeatherEventFormDirector"/>
    public class WeatherEventFormDirector : BaseFormDirector<WeatherEvent, WeatherEventFormGuide>, IWeatherEventFormDirector
    {
        protected readonly ILocationFormDirector locationFormDirector;

        /// <inheritdoc cref="BaseFormDirector{T}(IUnitOfWork)"/>
        public WeatherEventFormDirector(
            IUnitOfWork unitOfWork,
            ILocationFormDirector locationFormDirector
        ) : base(unitOfWork)
        {
            this.locationFormDirector = locationFormDirector;
        }

        public override async Task<WeatherEventFormGuide> GetGuideAsync(WeatherEvent model, FormGuideContext context) =>
            new WeatherEventFormGuide
            {
                Name = GetNameFormGuide(model),
                Experience = await GetExperienceFormGuide(model),
                Weather = await GetWeatherFormGuide(model),
                StartDate = GetStartDateFormGuide(model),
                EndDate = GetEndDateFormGuide(model),
                Description = GetDescriptionFormGuide(model),
                Locations = await GetLocationsFormGuides(model, context),
                Alerts = await GetAlertsFormGuides(model),
                Statistics = await GetWeatherEventStatisticsGuides(model)
            };

        protected virtual FormControl<string> GetNameFormGuide(WeatherEvent model) =>
            new()
            {
                Validation = FormControlValidators.Required
            };

        protected virtual async Task<FormControl<WeatherExperience>> GetExperienceFormGuide(WeatherEvent model) =>
            new()
            {
                Validation = FormControlValidators.Required,
                SuppliedValues = await GetValuesFromRepository(unitOfWork.WeatherExperiences, x => x.Name) // new List<SelectFormControlData.Option> { new("Test", 1) } 
            };

        protected virtual async Task<FormControl<Weather>> GetWeatherFormGuide(WeatherEvent model) =>
            new()
            {
                Validation = FormControlValidators.Required,
                SuppliedValues = await GetValuesFromRepository(unitOfWork.Weather, x => x.Name)
            };

        protected virtual FormControl<DateTimeOffset> GetStartDateFormGuide(WeatherEvent model) =>
            new()
            {
                Validation = FormControlValidators.Required
            };

        protected virtual FormControl<DateTimeOffset> GetEndDateFormGuide(WeatherEvent model) =>
            new()
            {
                Validation = new FormControlValidation
                {
                    DateTimeValidation = new()
                    {
                        MinValue = model.StartDate != default ? model.StartDate : default
                    }
                }
            };

        protected virtual FormControl<string> GetDescriptionFormGuide(WeatherEvent model) =>
            new()
            {
                Validation = FormControlValidators.Default
            };

        public virtual async Task<IEnumerable<WeatherEventLocationFormGuide>> GetLocationsFormGuides(WeatherEvent model, FormGuideContext context) =>
            await Task.WhenAll(model.Locations.Select(async location => new WeatherEventLocationFormGuide
            {
                StartTime = new()
                {
                    Validation = FormControlValidators.Required
                },
                EndTime = new()
                {
                    Validation = new FormControlValidation
                    {
                        DateTimeValidation = new()
                        {
                            MinValue = location.StartTime != default ? location.StartTime : default
                        }
                    }
                },
                Location = await locationFormDirector.GetGuideAsync(location.Location, context)
            }));

        protected virtual async Task<IEnumerable<WeatherEventAlertFormGuide>> GetAlertsFormGuides(WeatherEvent model)
        {
            IEnumerable<FormControlValue<WeatherAlert>> alertOptions = await GetValuesFromRepository(unitOfWork.WeatherAlerts, x => x.Name);
            IEnumerable<FormControlValue<WeatherAlertModifier>> alertModifierOptions = await GetValuesFromRepository(unitOfWork.WeatherAlertModifiers, x => x.Name);

            // TODO: Filter modifier options based on the alert type

            return model.Alerts.Select(alert => new WeatherEventAlertFormGuide
            {
                Alert = new()
                {
                    Validation = FormControlValidators.Required,
                    SuppliedValues = alertOptions
                },
                IssuanceTime = new()
                {
                    Validation = FormControlValidators.Required
                },
                Modifiers = alert.Modifiers.Select(modifier => new FormControl<WeatherAlertModifier>()
                {
                    Validation = FormControlValidators.Required,
                    SuppliedValues = alertModifierOptions
                })
            });
        }

        protected virtual async Task<WeatherEventStatisticsFormGuide> GetWeatherEventStatisticsGuides(WeatherEvent model) =>
            new WeatherEventStatisticsFormGuide
            {
                DamageCost = new()
                {
                    Validation = FormControlValidators.Integer
                },
                Fatalities = new()
                {
                    Validation = FormControlValidators.Integer
                },
                EFRating = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Tornado")),
                    Validation = FormControlValidators.Default,
                    SuppliedValues = new List<FormControlValue<int>>
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
                PathDistance = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Tornado")),
                    Validation = FormControlValidators.Integer
                },
                FunnelWidth = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Tornado")),
                    Validation = FormControlValidators.Integer
                },
                SaffirSimpsonRating = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    Validation = FormControlValidators.Default,
                    SuppliedValues = new List<FormControlValue<int>>
                    {
                        new("Category 1", 1),
                        new("Category 2", 2),
                        new("Category 3", 3),
                        new("Category 4", 4),
                        new("Category 5", 5)
                    }
                },
                LowestPressure = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    Validation = FormControlValidators.Numeric
                },
                MaxWindSpeed = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    Validation = FormControlValidators.Integer
                },
                RichterMagnitude = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Hurricane")),
                    Validation = FormControlValidators.Numeric
                },
                MercalliIntensity = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    Validation = FormControlValidators.Numeric
                },
                Aftershocks = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    Validation = FormControlValidators.Default,
                    SuppliedValues = new List<FormControlValue<int>>
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
                Fault = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    Validation = FormControlValidators.Integer
                },
                RelatedTsunami = new()
                {
                    ReadOnly = !model.Weather.Id.OneOf(await unitOfWork.Weather.GetWeatherIdByName("Earthquake")),
                    Validation = FormControlValidators.Default
                }
            };
    }
}
