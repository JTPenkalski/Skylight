import { Injectable } from '@angular/core';

import { BaseFormMapper } from './index';
import { WeatherAlertModifier } from 'core/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertModifierFormMapper extends BaseFormMapper<WeatherAlertModifier, any> {
  public toPresentationModel(source: any): WeatherAlertModifier {
    throw new Error('Not implemented.');
  }

  public toFormModel(source: WeatherAlertModifier): any {
    throw new Error('Not implemented.');
  }
}
