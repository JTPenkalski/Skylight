import { BaseModel, WeatherAlertModifierOperation, WeatherEventAlert } from './index';

export class WeatherAlertModifier extends BaseModel {
  public name: string;
  public description: string;
  public bonus: number;
  public operation: WeatherAlertModifierOperation;
  public alerts: WeatherEventAlert[];

  constructor(
    id: number,
    name: string,
    description: string,
    bonus: number,
    operation: WeatherAlertModifierOperation,
    alerts: WeatherEventAlert[]
  ) {
    super(id);
    this.id = id;
    this.name = name;
    this.description = description;
    this.bonus = bonus;
    this.operation = operation;
    this.alerts = alerts;
  }
}
