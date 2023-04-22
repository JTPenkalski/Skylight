import { Injectable } from '@angular/core';

import { BaseFormMapper } from './index';
import { WeatherEventObservationMethod } from 'presentation/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventObservationMethodFormMapper extends BaseFormMapper<WeatherEventObservationMethod, any> {  
  public toPresentationModel(source: any): WeatherEventObservationMethod {
    throw new Error('Not implemented.');
  }

  public toDisplayModel(source: WeatherEventObservationMethod): any {
    throw new Error('Not implemented.');
  }
}
