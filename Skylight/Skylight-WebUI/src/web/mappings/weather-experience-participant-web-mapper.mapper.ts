import { Injectable } from '@angular/core';

import { WeatherExperienceParticipant } from 'core/models';
import { WeatherExperienceParticipantWebModel } from 'web/web-models';
import { BaseWebMapper, StormTrackerWebMapper, WeatherEventObservationMethodWebMapper, WeatherExperienceWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherExperienceParticipantWebMapper extends BaseWebMapper<WeatherExperienceParticipant, WeatherExperienceParticipantWebModel> {
  constructor(
    protected readonly weatherExperienceMapper: WeatherExperienceWebMapper,
    protected readonly stormTrackerMapper: StormTrackerWebMapper,
    protected readonly weatherEventObservationMethodMapper: WeatherEventObservationMethodWebMapper
  ) {
    super();
  }

  public toPresentationModel(source: WeatherExperienceParticipantWebModel): WeatherExperienceParticipant
  {
    return new WeatherExperienceParticipant(
      this.weatherExperienceMapper.toPresentationModel(source.experience),
      this.stormTrackerMapper.toPresentationModel(source.tracker),
      this.weatherEventObservationMethodMapper.toPresentationModel(source.observationMethod),
      source.id
    );
  }

  public toWebModel(source: WeatherExperienceParticipant): WeatherExperienceParticipantWebModel
  {
    return new WeatherExperienceParticipantWebModel(
      source.id,
      this.weatherExperienceMapper.toWebModel(source.experience),
      this.stormTrackerMapper.toWebModel(source.tracker),
      this.weatherEventObservationMethodMapper.toWebModel(source.observationMethod)
    );
  }
}
