import { WeatherEventAlertLocation as WebWeatherEventAlertLocation } from 'web/clients';

export class WeatherEventAlertLocation {
  constructor(
    public name: string,
    public state?: string,
  ) {}

  public static fromApi(data: WebWeatherEventAlertLocation): WeatherEventAlertLocation {
    return new WeatherEventAlertLocation(data.name!, data.state!);
  }
}
