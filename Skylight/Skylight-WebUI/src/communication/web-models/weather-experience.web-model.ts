import { IBaseWebModel, IWeatherEventWebModel, IWeatherExperienceParticipantWebModel } from "./index";

export interface IWeatherExperienceWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
  readonly startTime: Date;
  readonly endTime?: Date;
  readonly participants?: IWeatherExperienceParticipantWebModel[];
  readonly events?: IWeatherEventWebModel[];
}
