import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseMapper, WeatherEventAlertMapper } from './index';
import { WeatherAlertModifier } from 'core/models';
import { IWeatherAlertModifierWebModel } from 'communication/web-models';

@Injectable()
export class WeatherAlertModifierMapper extends BaseMapper<IWeatherAlertModifierWebModel, WeatherAlertModifier, any> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherEventAlertMapper: WeatherEventAlertMapper
  ) {
    super(formBuilder);
  }
  
  public toWebModel(presentationModel: WeatherAlertModifier): IWeatherAlertModifierWebModel
  {
    return {
      id: presentationModel.id,
      name: presentationModel.name,
      description: presentationModel.description,
      bonus: presentationModel.bonus,
      operation: presentationModel.operation,
      alerts: presentationModel.alerts?.map(a => this.weatherEventAlertMapper.toWebModel(a)) ?? undefined
    };
  }

  public toPresentationModel(formModel: any): WeatherAlertModifier {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: WeatherAlertModifier): any {
    throw new Error('Not implemented.');
  }
}
