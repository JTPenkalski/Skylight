import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseMapper, WeatherEventAlertMapper } from './index';
import { WeatherAlert } from 'core/models';
import { IWeatherAlertWebModel } from 'communication/web-models';

@Injectable()
export class WeatherAlertMapper extends BaseMapper<IWeatherAlertWebModel, WeatherAlert, any> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherEventAlertMapper: WeatherEventAlertMapper
  ) {
    super(formBuilder);
  }
  
  public toWebModel(presentationModel: WeatherAlert): IWeatherAlertWebModel
  {
    return {
      id: presentationModel.id,
      name: presentationModel.name,
      description: presentationModel.description,
      value: presentationModel.value,
      thirdParty: presentationModel.thirdParty,
      events: presentationModel.events?.map(e => this.weatherEventAlertMapper.toWebModel(e)) ?? []
    };
  }

  public toPresentationModel(formModel: any): WeatherAlert {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: WeatherAlert): any {
    throw new Error('Not implemented.');
  }
}
