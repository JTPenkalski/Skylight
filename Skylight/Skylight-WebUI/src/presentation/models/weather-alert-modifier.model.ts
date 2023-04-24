import { BaseModel, IBaseModel } from './index';
import { IWeatherAlertModifier as IWeatherAlertModifierWebModel, WeatherAlertModifierOperation } from 'web/web-models';

export interface IWeatherAlertModifier extends IWeatherAlertModifierWebModel, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherAlertModifier extends BaseModel implements IWeatherAlertModifier {
  public name: string;
  public description: string;
  public bonus: number;
  public operation: WeatherAlertModifierOperation;

  constructor(data?: IWeatherAlertModifier) {
    super(data);
    
    this.name = this.str(data?.name);
    this.description = this.str(data?.description);
    this.bonus = this.num(data?.bonus);
    this.operation = this.enum(data?.operation, WeatherAlertModifierOperation.Add);
  }
}
