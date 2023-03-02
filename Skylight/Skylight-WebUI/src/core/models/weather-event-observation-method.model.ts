import { BaseModel } from './index';

export class WeatherEventObservationMethod extends BaseModel {
  public name: string;
  public description: string;

  constructor(
    name: string,
    description: string, 
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
  }
}
