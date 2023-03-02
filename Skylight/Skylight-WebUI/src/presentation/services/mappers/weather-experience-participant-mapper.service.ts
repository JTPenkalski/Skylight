import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseMapper, StormTrackerMapper, WeatherEventObservationMethodMapper, WeatherExperienceMapper } from './index';
import { WeatherExperienceParticipant } from 'core/models';
import { IWeatherExperienceParticipantWebModel } from 'communication/web-models';


@Injectable()
export class WeatherExperienceParticipantMapper extends BaseMapper<IWeatherExperienceParticipantWebModel, WeatherExperienceParticipant, any> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherExperienceMapper: WeatherExperienceMapper,
    protected readonly stormTrackerMapper: StormTrackerMapper,
    protected readonly weatherEventObservationMethodMapper: WeatherEventObservationMethodMapper
  ) {
    super(formBuilder);
  }
  
  public toWebModel(presentationModel: WeatherExperienceParticipant): IWeatherExperienceParticipantWebModel
  {
    return {
      id: presentationModel.id,
      experience: this.weatherExperienceMapper.toWebModel(presentationModel.experience),
      tracker: this.stormTrackerMapper.toWebModel(presentationModel.tracker),
      observationMethod: this.weatherEventObservationMethodMapper.toWebModel(presentationModel.observationMethod)
    };
  }

  public toPresentationModel(formModel: any): WeatherExperienceParticipant {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: WeatherExperienceParticipant): any {
    throw new Error('Not implemented.');
  }
}
