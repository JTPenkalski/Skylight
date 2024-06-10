import { NewWeatherEventAlert as WebNewWeatherEventAlert, WeatherAlertLevel as WebWeatherAlertLevel } from 'web/clients';
import { NewWeatherEventAlert as HubNewWeatherEventAlert } from 'web/connections/weather-event-hub-connection/requests';
import { WeatherAlertLevel } from '.';

export class NewWeatherEventAlert {
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
    public code?: string 
  ) { }

  public static fromApi(data: WebNewWeatherEventAlert): NewWeatherEventAlert {
    return new NewWeatherEventAlert(
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
      data.code
    )
  }
  
  public static fromHub(data: HubNewWeatherEventAlert): NewWeatherEventAlert {
    return new NewWeatherEventAlert(
      data.sender,
      data.headline,
      data.instruction,
      data.description,
      data.sent,
      data.effective,
      data.expires,
      data.name,
      data.source,
      this.mapWeatherAlertLevel(data.level),
      data.code
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
