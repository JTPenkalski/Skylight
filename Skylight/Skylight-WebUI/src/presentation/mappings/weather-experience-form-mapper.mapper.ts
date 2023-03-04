import { Injectable } from '@angular/core';

import { BaseFormMapper } from './index';
import { WeatherExperience } from 'core/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherExperienceFormMapper extends BaseFormMapper<WeatherExperience, any> {
  public toPresentationModel(source: any): WeatherExperience {
    throw new Error('Not implemented.');
  }

  public toFormModel(source: WeatherExperience): any {
    throw new Error('Not implemented.');
  }
}
