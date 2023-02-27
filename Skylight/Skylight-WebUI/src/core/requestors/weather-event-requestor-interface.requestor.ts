import { IRequestor } from './index';
import { WeatherEvent } from 'core/models';

export interface IWeatherEventRequestor extends IRequestor<WeatherEvent> {
  
}
