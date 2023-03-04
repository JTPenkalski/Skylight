import { Injectable } from '@angular/core';

import { WeatherEventAlert } from 'core/models';
import { WeatherEventAlertWebModel } from 'web/web-models';
import { BaseWebMapper, WeatherAlertModifierWebMapper, WeatherAlertWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventAlertWebMapper extends BaseWebMapper<WeatherEventAlert, WeatherEventAlertWebModel> {
  constructor(
    protected readonly weatherAlertMapper: WeatherAlertWebMapper,
    protected readonly weatherAlertModifierMapper: WeatherAlertModifierWebMapper
  ) {
    super();
  }

  public toPresentationModel(source: WeatherEventAlertWebModel): WeatherEventAlert
  {
    return new WeatherEventAlert(
      this.weatherAlertMapper.toPresentationModel(source.alert),
      source.issuanceTime,
      source.modifiers.map(m => this.weatherAlertModifierMapper.toPresentationModel(m)),
      source.id
    );
  }

  public toWebModel(source: WeatherEventAlert): WeatherEventAlertWebModel
  {
    return new WeatherEventAlertWebModel(
      source.id,
      this.weatherAlertMapper.toWebModel(source.alert),
      source.issuanceTime,
      source.modifiers.map(m => this.weatherAlertModifierMapper.toWebModel(m))
    );
  }
}
