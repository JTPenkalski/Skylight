using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;

namespace Skylight.Data.Contexts.Initializers;

public class DefaultSkylightContextInitializer(ISkylightContext context) : ISkylightContextInitializer
{
    public async Task InitializeAsync()
    {
        // Reset Database
        await context.ResetAsync();

        // Weather
        var weather = new Weather[]
        {
            new()
            {
                Name = "Thunderstorm",
                Description = "A storm characterized by the presence of lightning and its acoustic effect known as thunder. Thunderstorms occur in a type of cloud known as a cumulonimbus. They are usually accompanied by strong winds and often produce heavy rain and sometimes snow, sleet, or hail, but some thunderstorms produce little precipitation or no precipitation at all.",
            },
            new()
            {
                Name = "Tornado",
                Description = "A violently rotating column of air that is in contact with both the surface of the Earth and a cumulonimbus cloud or, in rare cases, the base of a cumulus cloud with rotating debris and dust beneath it.",
            },
            new()
            {
                Name = "Hurricane",
                Description = "A rapidly rotating storm system characterized by a low-pressure center, a closed low-level atmospheric circulation, strong winds, and a spiral arrangement of thunderstorms that produce heavy rain and squalls. Depending on its location and strength, a tropical cyclone is referred to by different names, including hurricane, typhoon, tropical storm, cyclonic storm, tropical depression, or simply cyclone.",
            }
        };

        await context.Weather.AddRangeAsync(weather);

        // Weather Alert Modifiers
        var weatherAlertModifiers = new WeatherAlertModifier[]
        {
            new()
            {
                Name = "Radar Indicated",
                Description = "A potential tornado was spotted on the radar, indicated by rotation, debris, or otherwise.",
                Bonus = 0,
                Operation = WeatherAlertModifierOperation.Add,
            },
            new()
            {
                Name = "Observed",
                Description = "A live tornado was witnessed by the public, storm chasers, emergency management or law enforcement.",
                Bonus = 2,
                Operation = WeatherAlertModifierOperation.Add,
            }
        };

        await context.WeatherAlertModifiers.AddRangeAsync(weatherAlertModifiers);

        // Weather Alerts
        var weatherAlerts = new WeatherAlert[]
        {
            new()
            {
                Name = "Special Weather Statement",
                Description = "Issued for hazards that have not yet reached warning or advisory status or that do not have a specific code of their own.",
                Source = "National Weather Service",
                Severity = 1,
            },
            new()
            {
                Name = "Advisory",
                Description = "Severe weather conditions are growing in favorability. As the conditions improve, watches and warnings may be issued.",
                Source = "National Weather Service",
                Severity = 1,
            },
            new()
            {
                Name = "Watch",
                Description = "Severe weather is possible during the next few hours. Meteorological conditions are favorable for the development of severe weather.",
                Source = "National Weather Service",
                Severity = 2,
            },
            new()
            {
                Name = "Warning",
                Description = "Severe weather has been indicated by weather radar or reported by a witness. Residents in affected areas should take immediate safety precautions.",
                Source = "National Weather Service",
                Severity = 3,
            },
            new()
            {
                Name = "Lightning Alert",
                Description = "WeatherBug notification indicating the prescence of lightning strikes within 10 miles. Cover should be sought out immediately.",
                Source = "Weather Bug",
                Severity = 1,
            },
        };

        await context.WeatherAlerts.AddRangeAsync(weatherAlerts);

        // Commit Changes
        await context.CommitAsync();
    }
}