import { BaseModel, WeatherAlert, WeatherAlertModifier, WeatherEvent } from './index';

export class WeatherEventAlert extends BaseModel {
  public alert: WeatherAlert;
  public issuanceTime: Date;
  public modifiers: WeatherAlertModifier[];

  constructor(
    alert: WeatherAlert = new WeatherAlert(),
    issuanceTime: Date = new Date(),
    modifiers: WeatherAlertModifier[] = [ new WeatherAlertModifier() ],
    id?: number
  ) {
    super(id);
    this.alert = alert;
    this.issuanceTime = issuanceTime;
    this.modifiers = modifiers;
  }
}
