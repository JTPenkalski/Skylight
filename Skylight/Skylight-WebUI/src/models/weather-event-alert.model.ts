import { BaseModel, IBaseModel, Weather, WeatherAlert, WeatherAlertModifier, WeatherEvent } from "./index";

export interface IWeatherEventAlert extends IBaseModel {
  event: WeatherEvent;
  alert: WeatherAlert;
  modifiers: WeatherAlertModifier[];
}

export class WeatherEventAlert extends BaseModel implements IWeatherEventAlert {
  public event: WeatherEvent;
  public alert: WeatherAlert;
  public modifiers: WeatherAlertModifier[];

  constructor(event: WeatherEvent);
  constructor(
    event: WeatherEvent,
    id?: number,
    alert?: WeatherAlert,
    modifiers?: WeatherAlertModifier[]
  ) {
    super(id);
    this.event = event ?? new WeatherEvent();
    this.alert = alert ?? new WeatherAlert();
    this.modifiers = modifiers ?? [];
  }
}
