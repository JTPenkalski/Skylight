import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseMapper, WeatherEventMapper, WeatherExperienceParticipantMapper } from './index';
import { WeatherExperience } from 'core/models';
import { IWeatherExperienceWebModel } from 'communication/web-models';

@Injectable()
export class WeatherExperienceMapper extends BaseMapper<IWeatherExperienceWebModel, WeatherExperience, any> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherEventMapper: WeatherEventMapper,
    protected readonly weatherExperienceParticipantMapper: WeatherExperienceParticipantMapper
  ) {
    super(formBuilder);
  }
  
  public toWebModel(presentationModel: WeatherExperience): IWeatherExperienceWebModel
  {
    return {
      id: presentationModel.id,
      name: presentationModel.name,
      description: presentationModel.description,
      startTime: presentationModel.startTime,
      endTime: presentationModel.endTime,
      participants: presentationModel.participants?.map(p => this.weatherExperienceParticipantMapper.toWebModel(p)) ?? undefined,
      events: presentationModel.events?.map(e => this.weatherEventMapper.toWebModel(e))
    };
  }

  public toPresentationModel(formModel: any): WeatherExperience {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: WeatherExperience): any {
    throw new Error('Not implemented.');
  }
}
