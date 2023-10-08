import { WeatherEvent } from 'presentation/models';
import { IService } from './index';
import { WeatherEventFormGuide } from 'web/models';

export interface IWeatherEventService extends IService<WeatherEvent, WeatherEventFormGuide> {
  
}