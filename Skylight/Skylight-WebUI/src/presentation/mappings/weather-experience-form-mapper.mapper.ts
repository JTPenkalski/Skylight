import { Injectable } from '@angular/core';

import { BaseFormMapper } from './index';
import { WeatherExperience } from 'presentation/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherExperienceFormMapper extends BaseFormMapper<WeatherExperience, any> {
  public toPresentationModel(source: any): WeatherExperience {
    throw new Error('Not implemented.');
  }

  public toDisplayModel(source: WeatherExperience): any {
    throw new Error('Not implemented.');
  }
}
