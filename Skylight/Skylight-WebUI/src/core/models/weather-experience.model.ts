import { BaseModel, WeatherEvent, WeatherExperienceParticipant } from './index';

export class WeatherExperience extends BaseModel {
  public name: string;
  public description: string;
  public startTime: Date;
  public endTime?: Date;

  constructor(
    name: string = '',
    description: string = '',
    startTime: Date = new Date(),
    endTime?: Date,
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.startTime = startTime;
    this.endTime = endTime;
  }
}
