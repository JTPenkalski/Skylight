import { WeatherEventAlert as WebWeatherEventAlert } from 'web/clients';
import { WeatherAlertLevel, WeatherEventAlertLocation, mapWeatherAlertLevel } from '.';

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
    public locations?: WeatherEventAlertLocation[],
  ) {}

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
      mapWeatherAlertLevel(data.level),
      data.code,
      data.locations?.map((x) => WeatherEventAlertLocation.fromApi(x)),
    );
  }
}
