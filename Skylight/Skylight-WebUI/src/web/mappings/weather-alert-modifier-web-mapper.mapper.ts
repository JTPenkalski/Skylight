import { Injectable } from '@angular/core';

import { WeatherAlertModifier } from 'core/models';
import { WeatherAlertModifierWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertModifierWebMapper extends BaseWebMapper<WeatherAlertModifier, WeatherAlertModifierWebModel> {
  public toPresentationModel(source: WeatherAlertModifierWebModel): WeatherAlertModifier
  {
    return new WeatherAlertModifier(
      source.name,
      source.description,
      source.bonus,
      source.operation,
      source.id
    );
  }

  public toWebModel(source: WeatherAlertModifier): WeatherAlertModifierWebModel
  {
    return new WeatherAlertModifierWebModel(
      source.id,
      source.name,
      source.description,
      source.bonus,
      source.operation
    );
  }
}
