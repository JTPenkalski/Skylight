import { IBaseWebModel, IStormTrackerWebModel, IWeatherEventObservationMethodWebModel, IWeatherExperienceWebModel } from "./index";

export interface IWeatherExperienceParticipantWebModel extends IBaseWebModel {
  readonly experience: IWeatherExperienceWebModel;
  readonly tracker: IStormTrackerWebModel;
  readonly observationMethod: IWeatherEventObservationMethodWebModel;
}
