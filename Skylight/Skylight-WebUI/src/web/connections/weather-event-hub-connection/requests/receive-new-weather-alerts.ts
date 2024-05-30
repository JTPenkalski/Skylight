import { WeatherAlertLevel } from 'web/clients';

export const ReceiveNewWeatherAlertsRequestName: string = 'ReceiveNewWeatherAlerts';

export interface ReceiveNewWeatherAlertsRequest {
  newWeatherEventAlerts: NewWeatherEventAlert[];
}

export interface NewWeatherEventAlert {
  sender: string,
  headline: string,
  instruction: string,
  description: string,
  sent: Date,
  effective: Date,
  expires: Date,
  name: string,
  source: string,
  level: WeatherAlertLevel,
  code?: string
}