import { BaseModel, IBaseModel, WeatherEventAlert } from "./index";

export interface IWeatherAlert extends IBaseModel {
  name: string;
  description: string;
  value: number;
  thirdParty: boolean;
  events: WeatherEventAlert[];
}

export class WeatherAlert extends BaseModel implements IWeatherAlert {
  public name: string;
  public description: string;
  public value: number;
  public thirdParty: boolean;
  public events: WeatherEventAlert[];

  constructor(
    id: number,
    name: string,
    description: string,
    value: number,
    thirdParty: boolean,
    events: WeatherEventAlert[]
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.value = value;
    this.thirdParty = thirdParty;
    this.events = events;
  }
}
