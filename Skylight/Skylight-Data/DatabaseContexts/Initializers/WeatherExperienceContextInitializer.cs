using Skylight.Models;

namespace Skylight.DatabaseContexts.Initializers
{
    /// <summary>
    /// Used for testing purposes.
    /// Initializes Weather Experience Contexts with the necessary data to use and query the APIs.
    /// </summary>
    public static class WeatherExperienceContextInitializer
    {
        /// <summary>
        /// Seeds the Weather Experience Context with preliminary data.
        /// </summary>
        /// <param name="weatherExperienceContext"></param>
        public static void Initialize(WeatherExperienceContext weatherExperienceContext)
        {
            // Weather Types
            Weather[] weather = new Weather[]
            {
                new(
                    "Thunderstorm",
                    "A storm characterized by the presence of lightning and its acoustic effect known as thunder. Thunderstorms occur in a type of cloud known as a cumulonimbus. They are usually accompanied by strong winds and often produce heavy rain and sometimes snow, sleet, or hail, but some thunderstorms produce little precipitation or no precipitation at all."
                ),
                new(
                    "Tornado",
                    "A violently rotating column of air that is in contact with both the surface of the Earth and a cumulonimbus cloud or, in rare cases, the base of a cumulus cloud with rotating debris and dust beneath it."
                ),
                new(
                    "Hurriance",
                    "A rapidly rotating storm system characterized by a low-pressure center, a closed low-level atmospheric circulation, strong winds, and a spiral arrangement of thunderstorms that produce heavy rain and squalls. Depending on its location and strength, a tropical cyclone is referred to by different names, including hurricane, typhoon, tropical storm, cyclonic storm, tropical depression, or simply cyclone."
                )
            };

            weatherExperienceContext.Weather.AddRange(weather);
            weatherExperienceContext.SaveChanges();

            // Risk Categories
            RiskCategory[] riskCategories = new RiskCategory[]
            {
                new(
                    "TSTM",
                    "General Thunderstorm",
                    "Althrough severe weather is not expected, all thunderstorms can produce deadly lighting, gusty winds, and small hail.",
                    "No severe thunderstorms expected.",
                    RiskCategoryOutlookProbability.Merge(
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Thunderstorm, 1, (10, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Thunderstorm, 2, (10, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Combined,     3, (10, false))
                    )
                ),
                new(
                    "MRGL",
                    "Marginal",
                    "Some storms could be capable of damaging winds and severe hail. Localized tornado threat could develop.",
                    "Isolated severe storms possible.",
                    RiskCategoryOutlookProbability.Merge(
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  1, (2, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     1, (5, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     1, (5, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  2, (2, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     2, (5, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     2, (5, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Combined, 3, (5, false))
                    )
                ),
                new(
                    "SLGT",
                    "Slight",
                    "Increased confidence that some storms will contain damaging winds, severe hail, and/or tornado potential.",
                    "Isolated to scattered severe storms expected.",
                    RiskCategoryOutlookProbability.Merge(
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  1, (5, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     1, (15, false), (15, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     1, (15, false), (15, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  2, (15, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     2, (15, false), (15, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     2, (15, false), (15, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Combined, 3, (15, false), (15, true))
                    )
                ),
                new(
                    "ENH",
                    "Enhanced",
                    "High confidence that several storms will contain damaging winds, severe hail, and/or tornadoes.",
                    "Scattered to numerous severe storms expected.",
                    RiskCategoryOutlookProbability.Merge(
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  1, (10, false), (10, true), (15, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     1, (30, false), (30, true), (45, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     1, (30, false), (30, true), (45, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  2, (10, false), (10, true), (15, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     2, (30, false), (30, true), (45, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     2, (30, false), (30, true), (45, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Combined, 3, (30, false), (30, true), (45, false))
                    )
                ),
                new(
                    "MDT",
                    "Moderate",
                    "High confidence that many storms will contain damaging winds, severe hail, and/or tornadoes.",
                    "Scattered to numerous severe storms expected.",
                    RiskCategoryOutlookProbability.Merge(
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  1, (15, true), (30, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     1, (45, true), (60, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     1, (45, true), (60, false), (60, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  2, (15, true), (30, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     2, (45, true), (60, false)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Hail,     2, (45, true), (60, false), (60, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Combined, 3, (45, true))
                    )
                ),
                new(
                    "HIGH",
                    "High",
                    "High confidence that an outbreak of storms will contain tornadoes, damaging winds, and/or severe hail.",
                    "Numerous severe storms expected.",
                    RiskCategoryOutlookProbability.Merge(
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  1, (30, true), (45, false), (45, true), (60, false), (60, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     1, (60, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Tornado,  2, (30, true), (45, false), (45, true), (60, false), (60, true)),
                        RiskCategoryOutlookProbability.Build(OutlookProbabilityWeatherType.Wind,     2, (60, true))
                    )
                )
            };

            weatherExperienceContext.RiskCategories.AddRange(riskCategories);
            weatherExperienceContext.SaveChanges();

            // Weather Alert Modifiers
            WeatherAlertModifier[] weatherAlertModifiers = new WeatherAlertModifier[]
            {
                new(
                    "Radar Indicated",
                    "A potential tornado was spotted on the radar, indicated by rotation, debris, or otherwise.",
                    0,
                    WeatherAlertModifierOperation.Add
                ),
                new(
                    "Observed",
                    "A live tornado was witnessed by the public, storm chasers, emergency management or law enforcement.",
                    2,
                    WeatherAlertModifierOperation.Add
                )
            };

            weatherExperienceContext.WeatherAlertModifiers.AddRange(weatherAlertModifiers);
            weatherExperienceContext.SaveChanges();

            // Weather Alerts
            WeatherAlert[] weatherAlerts = new WeatherAlert[]
            {
                new(
                    "Special Weather Statement",
                    "Issued for hazards that have not yet reached warning or advisory status or that do not have a specific code of their own.",
                    1,
                    false
                ),
                new(
                    "Advisory",
                    "Severe weather conditions are growing in favorability. As the conditions improve, watches and warnings may be issued.",
                    1,
                    false
                ),
                new(
                    "Watch",
                    "Severe weather is possible during the next few hours. Meteorological conditions are favorable for the development of severe weather.",
                    2,
                    false
                ),
                new(
                    "Warning",
                    "Severe weather has been indicated by weather radar or reported by a witness. Residents in affected areas should take immediate safety precautions.",
                    3,
                    false
                ),
                new(
                    "Lightning Alert",
                    "WeatherBug notification indicating the prescence of lightning strikes within 10 miles. Cover should be sought out immediately.",
                    1,
                    true
                )
            };

            weatherExperienceContext.WeatherAlerts.AddRange(weatherAlerts);
            weatherExperienceContext.SaveChanges();

            // Weather Event Observation Methods
            WeatherEventObservationMethod[] weatherEventObservationMethods = new WeatherEventObservationMethod[]
            {
                new(
                    "Chased",
                    "You were present at the Experience. You physically followed and intercepted the weather events as they occurred."
                ),
                new(
                    "Tracked",
                    "You were not present at the Experience. However, you actively participated in news as it was released and viewed live coverage of the events as they occurred."
                )
            };

            weatherExperienceContext.WeatherEventObservationMethods.AddRange(weatherEventObservationMethods);
            weatherExperienceContext.SaveChanges();
        }
    }
}