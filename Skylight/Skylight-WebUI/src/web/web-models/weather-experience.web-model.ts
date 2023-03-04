import { BaseWebModel, WeatherEventWebModel, WeatherExperienceParticipantWebModel } from './index';

export class WeatherExperienceWebModel extends BaseWebModel {
  public readonly name: string;
  public readonly description: string;
  public readonly startTime: Date;
  public readonly endTime?: Date;

  constructor(
    id: number,
    name: string,
    description: string,
    startTime: Date,
    endTime?: Date,
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.startTime = startTime;
    this.endTime = endTime;
  }
}
