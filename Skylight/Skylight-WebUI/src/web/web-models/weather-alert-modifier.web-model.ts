import { WeatherAlertModifierOperation } from 'core/models';
import { BaseWebModel } from './index';

export class WeatherAlertModifierWebModel extends BaseWebModel {
  public readonly name: string;
  public readonly description: string;
  public readonly bonus: number;
  public readonly operation: WeatherAlertModifierOperation;

  constructor(
    id: number,
    name: string,
    description: string,
    bonus: number,
    operation: WeatherAlertModifierOperation
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.bonus = bonus;
    this.operation = operation
  }
}
