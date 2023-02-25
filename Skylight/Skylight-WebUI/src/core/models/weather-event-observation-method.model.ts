import { BaseModel, IBaseModel } from "./index";

export interface IWeatherEventObservationMethod extends IBaseModel {
  name: string;
  description: string;
}

export class WeatherEventObservationMethod extends BaseModel implements IWeatherEventObservationMethod {
  public name: string;
  public description: string;

  constructor(id: number, name: string, description: string) {
    super(id);
    this.name = name;
    this.description = description;
  }
}
