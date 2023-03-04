import { Injectable } from '@angular/core';

import { BaseFormMapper } from './index';
import { WeatherEventObservationMethod } from 'core/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventObservationMethodFormMapper extends BaseFormMapper<WeatherEventObservationMethod, any> {  
  public toPresentationModel(source: any): WeatherEventObservationMethod {
    throw new Error('Not implemented.');
  }

  public toFormModel(source: WeatherEventObservationMethod): any {
    throw new Error('Not implemented.');
  }
}
