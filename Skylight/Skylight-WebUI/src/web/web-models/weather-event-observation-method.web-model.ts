import { BaseWebModel } from './index';

export class WeatherEventObservationMethodWebModel extends BaseWebModel {
  public readonly name: string;
  public readonly description: string;

  constructor(
    id: number,
    name: string,
    description: string
  ) {
    super(id);
    this.name = name;
    this.description = description;
  }
}
