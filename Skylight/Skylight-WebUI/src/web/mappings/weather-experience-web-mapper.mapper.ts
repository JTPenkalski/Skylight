import { Injectable } from '@angular/core';

import { WeatherExperience } from 'core/models';
import { WeatherExperienceWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherExperienceWebMapper extends BaseWebMapper<WeatherExperience, WeatherExperienceWebModel> {
  public toPresentationModel(source: WeatherExperienceWebModel): WeatherExperience
  {
    return new WeatherExperience(
      source.name,
      source.description,
      source.startTime,
      source.endTime,
      source.id
    );
  }

  public toWebModel(source: WeatherExperience): WeatherExperienceWebModel
  {
    return new WeatherExperienceWebModel(
      source.id,
      source.name,
      source.description,
      source.startTime,
      source.endTime
    );
  }
}
