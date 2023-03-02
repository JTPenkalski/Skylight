import { IRequestor } from './index';
import { IWeatherEventWebModel } from 'communication/web-models';

export interface IWeatherEventRequestor extends IRequestor<IWeatherEventWebModel> {
  
}
