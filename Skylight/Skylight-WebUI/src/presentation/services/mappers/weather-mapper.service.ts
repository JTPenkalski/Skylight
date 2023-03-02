import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseMapper, WeatherEventMapper } from './index';
import { Weather } from 'core/models';
import { IWeatherWebModel } from 'communication/web-models';

@Injectable()
export class WeatherMapper extends BaseMapper<IWeatherWebModel, Weather, any> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherEventMapper: WeatherEventMapper
  ) {
    super(formBuilder);
  }
  
  public toWebModel(presentationModel: Weather): IWeatherWebModel
  {
    return {
      id: presentationModel.id,
      name: presentationModel.name,
      description: presentationModel.description,
      events: presentationModel.events?.map(e => this.weatherEventMapper.toWebModel(e)) ?? undefined
    };
  }

  public toPresentationModel(formModel: any): Weather {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: Weather): any {
    throw new Error('Not implemented.');
  }
}
