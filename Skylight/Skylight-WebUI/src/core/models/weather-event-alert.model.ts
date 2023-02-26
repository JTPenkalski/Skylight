import { BaseModel, WeatherAlert, WeatherAlertModifier, WeatherEvent } from './index';

export class WeatherEventAlert extends BaseModel {
  public event: WeatherEvent | null;
  public alert: WeatherAlert;
  public modifiers: WeatherAlertModifier[];

  constructor(
    id: number = 0,
    event: WeatherEvent | null,
    alert: WeatherAlert = new WeatherAlert(),
    modifiers: WeatherAlertModifier[] = []
  ) {
    super(id);
    this.event = event;
    this.alert = alert;
    this.modifiers = modifiers ?? [];
  }
}
