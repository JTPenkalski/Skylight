using Skylight.Models;

namespace Skylight.Contexts
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
            int weatherTypeId = 0;
            WeatherType[] weatherTypes = new[]
            {
                new WeatherType(
                    weatherTypeId++,
                    "Thunderstorm",
                    "A storm characterized by the presence of lightning and its acoustic effect known as thunder. Thunderstorms occur in a type of cloud known as a cumulonimbus. They are usually accompanied by strong winds and often produce heavy rain and sometimes snow, sleet, or hail, but some thunderstorms produce little precipitation or no precipitation at all."
                ),
                new WeatherType(
                    weatherTypeId++,
                    "Tornado",
                    "A violently rotating column of air that is in contact with both the surface of the Earth and a cumulonimbus cloud or, in rare cases, the base of a cumulus cloud with rotating debris and dust beneath it."
                ),
                new WeatherType(
                    weatherTypeId++,
                    "Hurriance",
                    "A rapidly rotating storm system characterized by a low-pressure center, a closed low-level atmospheric circulation, strong winds, and a spiral arrangement of thunderstorms that produce heavy rain and squalls. Depending on its location and strength, a tropical cyclone is referred to by different names, including hurricane, typhoon, tropical storm, cyclonic storm, tropical depression, or simply cyclone."
                )
            };

            weatherExperienceContext.WeatherTypes.AddRange(weatherTypes);
            weatherExperienceContext.SaveChanges();

            // Risk Categories

            int riskCategoryId = 0;
            RiskCategory[] riskCategories = new[]
            {
                new RiskCategory(
                    riskCategoryId++,
                    "TSTM",
                    "General Thunderstorm",
                    "Althrough severe weather is not expected, all thunderstorms can produce deadly lighting, gusty winds, and small hail.",
                    "No severe thunderstorms expected.",
                    RiskCategoryOutlookProbability.Unused,
                    RiskCategoryOutlookProbability.Unused,
                    RiskCategoryOutlookProbability.Unused
                ),
                new RiskCategory(
                    riskCategoryId++,
                    "MRGL",
                    "Marginal",
                    "Some storms could be capable of damaging winds and severe hail. Localized tornado threat could develop.",
                    "Isolated severe storms possible.",
                    RiskCategoryOutlookProbability.Build((0.02f, false)),
                    RiskCategoryOutlookProbability.Build((0.05f, false)),
                    RiskCategoryOutlookProbability.Build((0.05f, false))
                ),
                new RiskCategory(
                    riskCategoryId++,
                    "SLGT",
                    "Slight",
                    "Increased confidence that some storms will contain damaging winds, severe hail, and/or tornado potential.",
                    "Isolated to scattered severe storms expected.",
                    RiskCategoryOutlookProbability.Build((0.05f, false)),
                    RiskCategoryOutlookProbability.Build((0.15f, false), (0.15f, true)),
                    RiskCategoryOutlookProbability.Build((0.15f, false), (0.15f, true))
                ),
                new RiskCategory(
                    riskCategoryId++,
                    "ENH",
                    "Enhanced",
                    "High confidence that several storms will contain damaging winds, severe hail, and/or tornadoes.",
                    "Scattered to numerous severe storms expected.",
                    RiskCategoryOutlookProbability.Build((0.10f, false), (0.10f, true), (0.15f, false)),
                    RiskCategoryOutlookProbability.Build((0.30f, false), (0.30f, true), (0.45f, false)),
                    RiskCategoryOutlookProbability.Build((0.30f, false), (0.30f, true), (0.45f, false))
                ),
                new RiskCategory(
                    riskCategoryId++,
                    "MDT",
                    "Moderate",
                    "High confidence that many storms will contain damaging winds, severe hail, and/or tornadoes.",
                    "Scattered to numerous severe storms expected.",
                    RiskCategoryOutlookProbability.Build((0.15f, true), (0.30f, false)),
                    RiskCategoryOutlookProbability.Build((0.45f, true), (0.60f, false)),
                    RiskCategoryOutlookProbability.Build((0.45f, true), (0.60f, false), (0.60f, true))
                ),
                new RiskCategory(
                    riskCategoryId++,
                    "HIGH",
                    "High",
                    "High confidence that an outbreak of storms will contain tornadoes, damaging winds, and/or severe hail.",
                    "Numerous severe storms expected.",
                    RiskCategoryOutlookProbability.Build((0.30f, true), (0.45f, false), (0.45f, true), (0.60f, false), (0.60f, true)),
                    RiskCategoryOutlookProbability.Build((0.60f, true)),
                    RiskCategoryOutlookProbability.Unused
                )
            };

            weatherExperienceContext.RiskCategories.AddRange(riskCategories);
            weatherExperienceContext.SaveChanges();

            // Weather Alerts

            int weatherAlertId = 0;
            WeatherAlert[] weatherAlerts = new[]
            {
                new WeatherAlert(
                    weatherAlertId++,
                    "Advisory",
                    "Severe weather conditions are growing in favorability. As the conditions improve, watches and warnings may be issued.",
                    1,
                    false
                ),
                new WeatherAlert(
                    weatherAlertId++,
                    "Watch",
                    "Severe weather is possible during the next few hours. Meteorological conditions are favorable for the development of severe weather.",
                    2,
                    false
                ),
                new WeatherAlert(
                    weatherAlertId++,
                    "Warning",
                    "Severe weather has been indicated by weather radar or reported by a witness. Residents in affected areas should take immediate safety precautions.",
                    3,
                    false
                ),
                new WeatherAlert(
                    weatherAlertId++,
                    "Alert",
                    "WeatherBug notification indicating the prescence of lightning strikes within 10 miles. Cover should be sought out immediately.",
                    1,
                    true
                )
            };

            weatherExperienceContext.WeatherAlerts.AddRange(weatherAlerts);
            weatherExperienceContext.SaveChanges();

            // Weather Alert Modifiers

            int weatherAlertModifierId = 0;
            WeatherAlertModifier[] weatherAlertModifiers = new[]
            {
                new WeatherAlertModifier(
                    weatherAlertModifierId++,
                    "Radar Indicated",
                    "A potential tornado was spotted on the radar, indicated by rotation, debris, or otherwise.",
                    0,
                    WeatherAlertModifierOperation.Add
                ),
                new WeatherAlertModifier(
                    weatherAlertModifierId++,
                    "Observed",
                    "A live tornado was witnessed by the public, storm chasers, emergency management or law enforcement.",
                    2,
                    WeatherAlertModifierOperation.Add
                )
            };

            weatherExperienceContext.WeatherAlertModifiers.AddRange(weatherAlertModifiers);
            weatherExperienceContext.SaveChanges();

            // Weather Event Observation Methods

            int weatherEventObservationMethodId = 0;
            WeatherEventObservationMethod[] weatherEventObservationMethods = new[]
            {
                new WeatherEventObservationMethod(
                    weatherEventObservationMethodId++,
                    "Chased",
                    "You were present at the Experience. You physically followed and intercepted the weather events as they occurred."
                ),
                new WeatherEventObservationMethod(
                    weatherEventObservationMethodId++,
                    "Tracked",
                    "You were not present at the Experience. However, you actively participated in news as it was released and viewed live coverage of the events as they occurred."
                )
            };

            weatherExperienceContext.WeatherEventObservationMethods.AddRange(weatherEventObservationMethods);
            weatherExperienceContext.SaveChanges();
        }
    }
}