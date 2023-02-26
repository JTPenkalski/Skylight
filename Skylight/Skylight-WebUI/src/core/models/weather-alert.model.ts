import { BaseModel, WeatherEventAlert } from './index';

export class WeatherAlert extends BaseModel {
  public name: string;
  public description: string;
  public value: number;
  public thirdParty: boolean;
  public events: WeatherEventAlert[];

  constructor(
    id: number = 0,
    name: string = '',
    description: string = '',
    value: number = 0,
    thirdParty: boolean = false,
    events: WeatherEventAlert[] = []
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.value = value;
    this.thirdParty = thirdParty;
    this.events = events;
  }
}
