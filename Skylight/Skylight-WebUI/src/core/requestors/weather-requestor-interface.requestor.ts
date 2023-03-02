import { IRequestor } from './index';
import { IWeatherWebModel } from 'communication/web-models';

export interface IWeatherRequestor extends IRequestor<IWeatherWebModel> {
  
}
