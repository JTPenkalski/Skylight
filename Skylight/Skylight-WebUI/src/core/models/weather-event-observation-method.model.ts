import { BaseModel } from './index';

export class WeatherEventObservationMethod extends BaseModel {
  public name: string;
  public description: string;

  constructor(id: number, name: string, description: string) {
    super(id);
    this.name = name;
    this.description = description;
  }
}
