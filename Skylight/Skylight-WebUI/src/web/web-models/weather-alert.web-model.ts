import { BaseWebModel } from './index';

export class WeatherAlertWebModel extends BaseWebModel {
  public readonly name: string;
  public readonly description: string;
  public readonly value: number;
  public readonly thirdParty: boolean;

  constructor(
    id: number,
    name: string,
    description: string,
    value: number,
    thirdParty: boolean
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.value = value;
    this.thirdParty = thirdParty;
  }
}
