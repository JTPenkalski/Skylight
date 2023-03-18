import { BaseWebModel, StormTrackerWebModel, WeatherEventObservationMethodWebModel, WeatherExperienceWebModel } from './index';

export class WeatherExperienceParticipantWebModel extends BaseWebModel {
  public readonly experience: WeatherExperienceWebModel;
  public readonly tracker: StormTrackerWebModel;
  public readonly observationMethod: WeatherEventObservationMethodWebModel;

  constructor(
    id: number,
    experience: WeatherExperienceWebModel,
    tracker: StormTrackerWebModel,
    observationMethod: WeatherEventObservationMethodWebModel
  ) {
    super(id);
    this.experience = experience;
    this.tracker = tracker;
    this.observationMethod = observationMethod;
  }
}
