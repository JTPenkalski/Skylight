import { BaseModel, IBaseModel, StormTracker, WeatherEventObservationMethod, WeatherExperience } from "./index";

export interface IWeatherExperienceParticipant extends IBaseModel {
  experience: WeatherExperience;
  tracker: StormTracker;
  observationMethod: WeatherEventObservationMethod;
}

export class WeatherExperienceParticipant extends BaseModel implements IWeatherExperienceParticipant {
  public experience: WeatherExperience;
  public tracker: StormTracker;
  public observationMethod: WeatherEventObservationMethod;

  constructor(
    id: number,
    experience: WeatherExperience,
    tracker: StormTracker,
    observationMethod: WeatherEventObservationMethod
  ) {
    super(id);
    this.experience = experience;
    this.tracker = tracker;
    this.observationMethod = observationMethod;
  }
}
