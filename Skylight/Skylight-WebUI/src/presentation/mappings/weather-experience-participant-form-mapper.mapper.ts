import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseFormMapper, StormTrackerFormMapper, WeatherEventObservationMethodFormMapper, WeatherExperienceFormMapper } from './index';
import { WeatherExperienceParticipant } from 'presentation/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherExperienceParticipantFormMapper extends BaseFormMapper<WeatherExperienceParticipant, any> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly stormTrackerMapper: StormTrackerFormMapper,
    protected readonly weatherEventObservationMethodMapper: WeatherEventObservationMethodFormMapper
  ) {
    super(formBuilder);
  }

  public toPresentationModel(source: any): WeatherExperienceParticipant {
    throw new Error('Not implemented.');
  }

  public toDisplayModel(source: WeatherExperienceParticipant): any {
    throw new Error('Not implemented.');
  }
}
