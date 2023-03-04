import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseFormMapper, WeatherEventFormMapper } from './index';
import { Weather } from 'core/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherFormMapper extends BaseFormMapper<Weather, any> {
  public toPresentationModel(source: any): Weather {
    throw new Error('Not implemented.');
  }

  public toFormModel(source: Weather): any {
    throw new Error('Not implemented.');
  }
}
