import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseFormMapper, WeatherEventAlertFormMapper } from './index';
import { WeatherAlert } from 'core/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertFormMapper extends BaseFormMapper<WeatherAlert, any> {
  public toPresentationModel(source: any): WeatherAlert {
    throw new Error('Not implemented.');
  }

  public toDisplayModel(source: WeatherAlert): any {
    throw new Error('Not implemented.');
  }
}
