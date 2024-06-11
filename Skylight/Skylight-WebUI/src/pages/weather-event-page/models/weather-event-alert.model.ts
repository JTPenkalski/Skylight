import { WeatherEventAlert as WebWeatherEventAlert, WeatherAlertLevel as WebWeatherAlertLevel } from 'web/clients';
import { WeatherAlertLevel, WeatherEventAlertLocation } from '.';

export class WeatherEventAlert {
  constructor(
    public sender: string,
    public headline: string,
    public instruction: string,
    public description: string,
    public sent: Date,
    public effective: Date,
    public expires: Date,
    public name: string,
    public source: string,
    public level: WeatherAlertLevel,
    public code?: string,
    public locations?: WeatherEventAlertLocation[] 
  ) { }

  public static fromApi(data: WebWeatherEventAlert): WeatherEventAlert {
    return new WeatherEventAlert(
      data.sender!,
      data.headline!,
      data.instruction!,
      data.description!,
      data.sent!,
      data.effective!,
      data.expires!,
      data.name!,
      data.source!,
      this.mapWeatherAlertLevel(data.level),
      data.code,
      data.locations?.map(x => WeatherEventAlertLocation.fromApi(x))
    )
  }

  private static mapWeatherAlertLevel(webWeatherAlertLevel?: WebWeatherAlertLevel): WeatherAlertLevel {
    switch (webWeatherAlertLevel) {
      case WebWeatherAlertLevel.Warning: return WeatherAlertLevel.Warning;
      case WebWeatherAlertLevel.Watch || 1: return WeatherAlertLevel.Watch;
      case WebWeatherAlertLevel.Advisory || 2: return WeatherAlertLevel.Advisory;
      default: return WeatherAlertLevel.None;
    }
  }
}
