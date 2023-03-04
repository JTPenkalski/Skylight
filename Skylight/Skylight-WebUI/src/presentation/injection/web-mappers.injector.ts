import { InjectionToken, Provider } from '@angular/core';

import * as WebMappers from 'web/mappings';

// TOKENS
export const LOCATION_WEB_MAPPER = new InjectionToken<WebMappers.LocationWebMapper>('LOCATION_WEB_MAPPER');
export const STORM_TRACKER_WEB_MAPPER = new InjectionToken<WebMappers.StormTrackerWebMapper>('STORM_TRACKER_WEB_MAPPER');
export const WEATHER_ALERT_WEB_MAPPER = new InjectionToken<WebMappers.WeatherAlertWebMapper>('WEATHER_ALERT_WEB_MAPPER');
export const WEATHER_ALERT_MODIFIER_WEB_MAPPER = new InjectionToken<WebMappers.WeatherAlertModifierWebMapper>('WEATHER_ALERT_MODIFIER_WEB_MAPPER');
export const WEATHER_EVENT_ALERT_WEB_MAPPER = new InjectionToken<WebMappers.WeatherEventAlertWebMapper>('WEATHER_EVENT_ALERT_WEB_MAPPER');
export const WEATHER_EVENT_WEB_MAPPER = new InjectionToken<WebMappers.WeatherEventWebMapper>('WEATHER_EVENT_WEB_MAPPER');
export const WEATHER_EVENT_OBSERVATION_METHOD_WEB_MAPPER = new InjectionToken<WebMappers.WeatherEventObservationMethodWebMapper>('WEATHER_EVENT_OBSERVATION_METHOD_WEB_MAPPER');
export const WEATHER_EVENT_STATISTICS_WEB_MAPPER = new InjectionToken<WebMappers.WeatherEventStatisticsWebMapper>('WEATHER_EVENT_STATISTICS_WEB_MAPPER');
export const WEATHER_EXPERIENCE_WEB_MAPPER = new InjectionToken<WebMappers.WeatherExperienceWebMapper>('WEATHER_EXPERIENCE_WEB_MAPPER');
export const WEATHER_EXPERIENCE_PARTICIPANT_WEB_MAPPER = new InjectionToken<WebMappers.WeatherExperienceParticipantWebMapper>('WEATHER_EXPERIENCE_PARTICIPANT_WEB_MAPPER');
export const WEATHER_WEB_MAPPER = new InjectionToken<WebMappers.WeatherWebMapper>('WEATHER_WEB_MAPPER');

// SERVICES
// See src/web/mapping

// PROVIDERS
export const WEB_MAPPER_PROVIDERS: Provider[] = [
  { provide: LOCATION_WEB_MAPPER, useFactory: () => new WebMappers.LocationWebMapper(), deps: [] },
  { provide: STORM_TRACKER_WEB_MAPPER, useFactory: () => new WebMappers.StormTrackerWebMapper(), deps: [] },
  { provide: WEATHER_ALERT_WEB_MAPPER, useFactory: () => new WebMappers.WeatherAlertWebMapper(), deps: [] },
  { provide: WEATHER_ALERT_MODIFIER_WEB_MAPPER, useFactory: () => new WebMappers.WeatherAlertModifierWebMapper(), deps: [] },
  { provide: WEATHER_EVENT_ALERT_WEB_MAPPER,
    useFactory: (
      weatherAlertMapper: WebMappers.WeatherAlertWebMapper,
      weatherAlertModifierMapper: WebMappers.WeatherAlertModifierWebMapper,
      weatherEventMapper: WebMappers.WeatherEventWebMapper) => 
      new WebMappers.WeatherEventAlertWebMapper(weatherAlertMapper, weatherAlertModifierMapper, weatherEventMapper),
    deps: [WebMappers.WeatherAlertWebMapper, WebMappers.WeatherAlertModifierWebMapper, WebMappers.WeatherEventWebMapper]
  },
  { provide: WEATHER_EVENT_WEB_MAPPER,
    useFactory: (
      weatherMapper: WebMappers.WeatherWebMapper,
      weatherEventStatisticsMapper: WebMappers.WeatherEventStatisticsWebMapper,
      weatherExperienceMapper: WebMappers.WeatherExperienceWebMapper,
      locationsMapper: WebMappers.LocationWebMapper,
      weatherEventAlertsMapper: WebMappers.WeatherEventAlertWebMapper
    ) => new WebMappers.WeatherEventWebMapper(weatherMapper, weatherEventStatisticsMapper, weatherExperienceMapper, locationsMapper, weatherEventAlertsMapper),
    deps: [WebMappers.WeatherWebMapper, WebMappers.WeatherEventStatisticsWebMapper, WebMappers.WeatherExperienceWebMapper, WebMappers.LocationWebMapper, WebMappers.WeatherEventAlertWebMapper]
  },
  { provide: WEATHER_EVENT_OBSERVATION_METHOD_WEB_MAPPER, useFactory: () => new WebMappers.WeatherEventObservationMethodWebMapper(), deps: [] },
  { provide: WEATHER_EVENT_STATISTICS_WEB_MAPPER, useFactory: () => new WebMappers.WeatherEventStatisticsWebMapper(), deps: [] },
  { provide: WEATHER_EXPERIENCE_WEB_MAPPER,
    useFactory: (
      weatherExperienceParticipantMapper: WebMappers.WeatherExperienceParticipantWebMapper,
      weatherEventMapper: WebMappers.WeatherEventWebMapper
    ) => new WebMappers.WeatherExperienceWebMapper(weatherExperienceParticipantMapper, weatherEventMapper),
    deps: [WebMappers.WeatherExperienceParticipantWebMapper, WebMappers.WeatherEventWebMapper]
  },
  { provide: WEATHER_EXPERIENCE_PARTICIPANT_WEB_MAPPER,
    useFactory: (
      weatherExperienceMapper: WebMappers.WeatherExperienceWebMapper,
      stormTrackerMapper: WebMappers.StormTrackerWebMapper,
      weatherEventObservationMethodMapper: WebMappers.WeatherEventObservationMethodWebMapper
    ) => new WebMappers.WeatherExperienceParticipantWebMapper(weatherExperienceMapper, stormTrackerMapper, weatherEventObservationMethodMapper),
    deps: [WebMappers.WeatherExperienceWebMapper, WebMappers.StormTrackerWebMapper, WebMappers.WeatherEventObservationMethodWebMapper]
  },
  { provide: WEATHER_WEB_MAPPER, useFactory: () => new WebMappers.WeatherWebMapper(), deps: [] }
];
