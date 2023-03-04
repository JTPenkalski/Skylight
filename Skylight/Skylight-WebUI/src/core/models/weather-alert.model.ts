import { BaseModel } from './index';

export class WeatherAlert extends BaseModel {
  public name: string;
  public description: string;
  public value: number;
  public thirdParty: boolean;

  constructor(
    name: string = '',
    description: string = '',
    value: number = 0,
    thirdParty: boolean = false,
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.value = value;
    this.thirdParty = thirdParty;
  }
}
