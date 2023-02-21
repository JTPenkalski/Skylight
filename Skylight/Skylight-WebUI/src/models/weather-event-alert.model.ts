import { BaseModel, IBaseModel, WeatherAlert, WeatherAlertModifier, WeatherEvent } from "./index";

export interface IWeatherEventAlert extends IBaseModel {
  event: WeatherEvent;
  alert: WeatherAlert;
  modifiers: WeatherAlertModifier[];
}

export class WeatherEventAlert extends BaseModel implements IWeatherEventAlert {
  public event: WeatherEvent;
  public alert: WeatherAlert;
  public modifiers: WeatherAlertModifier[];

  constructor(
    id: number,
    event: WeatherEvent,
    alert: WeatherAlert,
    modifiers: WeatherAlertModifier[]
  ) {
    super(id);
    this.event = event;
    this.alert = alert;
    this.modifiers = modifiers;
  }
}
