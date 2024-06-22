import { WeatherAlertLevel as WebWeatherAlertLevel } from 'web/clients';

export enum WeatherAlertLevel {
  None = 'None',
  Advisory = 'Advisory',
  Watch = 'Watch',
  Warning = 'Warning',
}

export function mapWeatherAlertLevel(webWeatherAlertLevel?: WebWeatherAlertLevel): WeatherAlertLevel {
  switch (webWeatherAlertLevel) {
    case WebWeatherAlertLevel.Warning: return WeatherAlertLevel.Warning;
    case WebWeatherAlertLevel.Watch || 1: return WeatherAlertLevel.Watch;
    case WebWeatherAlertLevel.Advisory || 2: return WeatherAlertLevel.Advisory;
    default: return WeatherAlertLevel.None;
  }
}
