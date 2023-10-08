import { Modify } from 'core/types';
import { BaseModel, IBaseModel, IWeatherAlertModifier, WeatherAlertModifier } from './index';
import { IWeatherEventAlertModifier as IWeatherEventAlertModifierWebModel } from 'web/models';

export interface IWeatherEventAlertModifier extends Modify<IWeatherEventAlertModifierWebModel, {
  modifier: IWeatherAlertModifier
}>, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventAlertModifier extends BaseModel implements IWeatherEventAlertModifier {
  public modifier: WeatherAlertModifier;

  constructor(data?: IWeatherEventAlertModifier) {
    super(data);

    this.modifier = new WeatherAlertModifier(data?.modifier);
  }
}