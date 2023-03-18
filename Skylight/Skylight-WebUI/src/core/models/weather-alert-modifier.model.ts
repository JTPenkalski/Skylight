import { BaseModel, WeatherAlertModifierOperation } from './index';

export class WeatherAlertModifier extends BaseModel {
  public name: string;
  public description: string;
  public bonus: number;
  public operation: WeatherAlertModifierOperation;

  constructor(
    name: string = '',
    description: string = '',
    bonus: number = 0,
    operation: WeatherAlertModifierOperation = WeatherAlertModifierOperation.Add,
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.bonus = bonus;
    this.operation = operation;
  }
}
