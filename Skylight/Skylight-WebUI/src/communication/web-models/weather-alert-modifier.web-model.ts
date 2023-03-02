import { WeatherAlertModifierOperation } from 'core/models';
import { IBaseWebModel, IWeatherEventAlertWebModel } from './index';

export interface IWeatherAlertModifierWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
  readonly bonus: number;
  readonly operation: WeatherAlertModifierOperation;
  readonly alerts?: IWeatherEventAlertWebModel[];
}
