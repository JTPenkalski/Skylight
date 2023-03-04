import { IClient } from './index';
import { WeatherWebModel } from 'web/web-models';

export interface IWeatherClient extends IClient<WeatherWebModel> {
  
}
