import { Injectable } from '@angular/core';

import { BaseMapper } from './index';
import { WeatherEventObservationMethod } from 'core/models';
import { IWeatherEventObservationMethodWebModel } from 'communication/web-models';

@Injectable()
export class WeatherEventObservationMethodMapper extends BaseMapper<IWeatherEventObservationMethodWebModel, WeatherEventObservationMethod, any> {  
  public toWebModel(presentationModel: WeatherEventObservationMethod): IWeatherEventObservationMethodWebModel
  {
    return {
      id: presentationModel.id,
      name: presentationModel.name,
      description: presentationModel.description
    };
  }

  public toPresentationModel(formModel: any): WeatherEventObservationMethod {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: WeatherEventObservationMethod): any {
    throw new Error('Not implemented.');
  }
}
