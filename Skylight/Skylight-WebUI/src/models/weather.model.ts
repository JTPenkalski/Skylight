import { BaseModel, IBaseModel, WeatherEvent } from "./index";

export interface IWeather extends IBaseModel {
  name: string;
  description: string;
  events: WeatherEvent[];
}

export class Weather extends BaseModel implements IWeather {
  public name: string;
  public description: string;
  public events: WeatherEvent[];

  constructor(
    id: number,
    name: string,
    description: string,
    events: WeatherEvent[]
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.events = events;
  }
}
