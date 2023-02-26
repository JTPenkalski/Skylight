import { IRequestor } from './index';
import { Weather } from 'core/models';

export interface IWeatherRequestor extends IRequestor<Weather> {
  
}
