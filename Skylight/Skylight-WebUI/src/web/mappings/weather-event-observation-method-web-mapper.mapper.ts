import { Injectable } from '@angular/core';

import { WeatherEventObservationMethod } from 'core/models';
import { WeatherEventObservationMethodWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventObservationMethodWebMapper extends BaseWebMapper<WeatherEventObservationMethod, WeatherEventObservationMethodWebModel> {
  public toPresentationModel(source: WeatherEventObservationMethodWebModel): WeatherEventObservationMethod
  {
    return new WeatherEventObservationMethod(
      source.name,
      source.description,
      source.id
    );
  }

  public toWebModel(source: WeatherEventObservationMethod): WeatherEventObservationMethodWebModel
  {
    return new WeatherEventObservationMethodWebModel(
      source.id,
      source.name,
      source.description
    );
  }
}
