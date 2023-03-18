import { Injectable } from '@angular/core';

import { WeatherAlert } from 'core/models';
import { WeatherAlertWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertWebMapper extends BaseWebMapper<WeatherAlert, WeatherAlertWebModel> {
  public toPresentationModel(source: WeatherAlertWebModel): WeatherAlert
  {
    return new WeatherAlert(
      source.name,
      source.description,
      source.value,
      source.thirdParty,
      source.id
    );
  }

  public toWebModel(source: WeatherAlert): WeatherAlertWebModel
  {
    return new WeatherAlertWebModel(
      source.id,
      source.name,
      source.description,
      source.value,
      source.thirdParty
    );
  }
}
