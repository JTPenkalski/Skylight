import { BaseModel, IBaseModel, WeatherEvent, WeatherExperienceParticipant } from "./index";

export interface IWeatherExperience extends IBaseModel {
  name: string;
  description: string;
  startTime: Date;
  endTime: Date;
  participants: WeatherExperienceParticipant[];
  events: WeatherEvent[];
}

export class WeatherExperience extends BaseModel implements IWeatherExperience {
  public name: string;
  public description: string;
  public startTime: Date;
  public endTime: Date;
  public participants: WeatherExperienceParticipant[];
  public events: WeatherEvent[];

  constructor(
    id: number,
    name: string,
    description: string,
    startTime: Date,
    endTime: Date,
    participants: WeatherExperienceParticipant[],
    events: WeatherEvent[]
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.startTime = startTime;
    this.endTime = endTime;
    this.participants = participants;
    this.events = events;
  }
}
