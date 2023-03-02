import { BaseModel, WeatherEvent } from './index';

export class Weather extends BaseModel {
  public name: string;
  public description: string;
  public events?: WeatherEvent[];

  constructor(
    name: string = '',
    description: string = '',
    events?: WeatherEvent[],
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.events = events;
  }
}
