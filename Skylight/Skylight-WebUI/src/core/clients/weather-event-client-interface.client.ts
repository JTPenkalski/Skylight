import { IClient } from './index';
import { WeatherEventWebModel } from 'web/web-models';

export interface IWeatherEventClient extends IClient<WeatherEventWebModel> {
  
}
