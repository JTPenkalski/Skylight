import { Injectable } from '@angular/core';

import { Weather } from 'core/models';
import { WeatherWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherWebMapper extends BaseWebMapper<Weather, WeatherWebModel> {
  public toPresentationModel(source: WeatherWebModel): Weather
  {
    return new Weather(
      source.name,
      source.description,
      source.id
    );
  }

  public toWebModel(source: Weather): WeatherWebModel
  {
    return new WeatherWebModel(
      source.id,
      source.name,
      source.description
    );
  }
}
