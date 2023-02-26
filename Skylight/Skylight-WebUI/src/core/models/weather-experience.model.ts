import { BaseModel, WeatherEvent, WeatherExperienceParticipant } from './index';

export class WeatherExperience extends BaseModel {
  public name: string;
  public description: string;
  public startTime: Date;
  public endTime: Date | null;
  public participants: WeatherExperienceParticipant[];
  public events: WeatherEvent[];

  constructor(
    id: number = 0,
    name: string = '',
    description: string = '',
    startTime: Date = new Date(),
    endTime: Date | null = null,
    participants: WeatherExperienceParticipant[] = [],
    events: WeatherEvent[] = []
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
