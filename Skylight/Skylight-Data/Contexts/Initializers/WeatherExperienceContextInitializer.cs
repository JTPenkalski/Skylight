using Skylight.Models;
using Skylight.Repositories;
using System;
using System.Collections.Generic;

namespace Skylight.Contexts.Initializers
{
    /// <inheritdoc cref="IWeatherExperienceContextInitializer"/>
    public class WeatherExperienceContextInitializer : IWeatherExperienceContextInitializer
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly WeatherExperienceContext context;

        /// <summary>
        /// Constructs a new <see cref="WeatherExperienceContextInitializer"/> instance.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work service.</param>
        public WeatherExperienceContextInitializer(IUnitOfWork unitOfWork, WeatherExperienceContext context)
        {
            this.unitOfWork = unitOfWork;
            this.context = context; // TODO: Replace with repositories once they are set up.
        }

        /// <inheritdoc cref="IWeatherExperienceContextInitializer.Initialize"/>
        public void Initialize()
        {
            // Reset Database
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

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

            context.Weather.AddRange(weather);
            context.SaveChanges();

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

            context.RiskCategories.AddRange(riskCategories);
            context.SaveChanges();

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

            context.WeatherAlertModifiers.AddRange(weatherAlertModifiers);
            context.SaveChanges();

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

            context.WeatherAlerts.AddRange(weatherAlerts);
            context.SaveChanges();

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

            context.WeatherEventObservationMethods.AddRange(weatherEventObservationMethods);
            context.SaveChanges();

            // Weather Experiences (TEMP)
            WeatherExperience[] weatherExperiences = new WeatherExperience[]
            {
                new(
                    "Tornado Outbreak of December 10th, 2021 [TEMP]",
                    "A deadly late-season tornado outbreak, the deadliest on record in December, produced catastrophic damage and numerous fatalities across portions of the Southern United States and Ohio Valley from the evening of December 10 to the early morning of December 11, 2021. The event developed as a trough progressed eastward across the United States, interacting with an unseasonably moist and unstable environment across the Mississippi Valley. Tornado activity began in northeastern Arkansas, before progressing into Missouri, Illinois, Tennessee, and Kentucky.",
                    new DateTime(2021, 12, 10),
                    new DateTime(2021, 12, 11)
                )
            };

            context.WeatherExperiences.AddRange(weatherExperiences);
            context.SaveChanges();

            // Weather Events (TEMP)
            WeatherEvent[] weatherEvents = new WeatherEvent[]
            {
                new()
                {
                    Name = "Mayfield Tornado",
                    Description = "A destructive tornado in Mayfield KY.",
                    StartDate = new DateTime(2021, 12, 10),
                    EndDate = new DateTime(2021, 12, 11),
                    Weather = weather[0],
                    Experience = weatherExperiences[0],
                    Statistics = new()
                    {
                        DamageCost = 123,
                        Fatalities = 1,
                        EFRating = 1,
                        PathDistance = 23,
                        FunnelWidth = 45,
                        RelatedTsunami = true
                    },
                    Locations = new List<WeatherEventLocation>()
                    {
                        new()
                        {
                            Location = new Location("Chester", "12345"),
                            StartTime = new DateTime(2021, 12, 10, 12, 20, 0),
                            EndTime = new DateTime(2021, 12, 10, 12, 35, 0)
                        },
                        new()
                        {
                            Location = new Location("Platteville", "67890"),
                            StartTime = new DateTime(2021, 12, 10, 12, 35, 0),
                            EndTime = new DateTime(2021, 12, 10, 14, 00, 0)
                        },
                        new()
                        {
                            Location = new Location("France", "10101"),
                            StartTime = new DateTime(2021, 12, 10, 14, 00, 0),
                            EndTime = new DateTime(2021, 12, 10, 15, 15, 0)
                        }
                    },
                    Alerts = new List<WeatherEventAlert>()
                    {
                        new()
                        {
                            IssuanceTime = new DateTime(2021, 12, 10),
                            Alert = weatherAlerts[0],
                            Modifiers = new List<WeatherEventAlertModifier>()
                            {
                                new()
                                {
                                    Modifier = weatherAlertModifiers[0]
                                }
                            }
                        }
                    }
                }
            };

            context.WeatherEvents.AddRange(weatherEvents);
            context.SaveChanges();
        }
    }
}