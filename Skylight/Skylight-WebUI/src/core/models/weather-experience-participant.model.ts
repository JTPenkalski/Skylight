import { BaseModel, StormTracker, WeatherEventObservationMethod, WeatherExperience } from './index';

export class WeatherExperienceParticipant extends BaseModel {
  public experience: WeatherExperience;
  public tracker: StormTracker;
  public observationMethod: WeatherEventObservationMethod;

  constructor(
    experience: WeatherExperience,
    tracker: StormTracker,
    observationMethod: WeatherEventObservationMethod,
    id?: number
  ) {
    super(id);
    this.experience = experience;
    this.tracker = tracker;
    this.observationMethod = observationMethod;
  }
}
