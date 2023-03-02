import { BaseModel, WeatherAlertModifierOperation, WeatherEventAlert } from './index';

export class WeatherAlertModifier extends BaseModel {
  public name: string;
  public description: string;
  public bonus: number;
  public operation: WeatherAlertModifierOperation;
  public alerts?: WeatherEventAlert[];

  constructor(
    name: string = '',
    description: string = '',
    bonus: number = 0,
    operation: WeatherAlertModifierOperation = WeatherAlertModifierOperation.Add,
    alerts?: WeatherEventAlert[],
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.bonus = bonus;
    this.operation = operation;
    this.alerts = alerts;
  }
}
