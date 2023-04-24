import { BaseModel, IBaseModel } from './index';
import { IWeather as IWeatherWebModel } from 'web/web-models';

export interface IWeather extends IWeatherWebModel, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class Weather extends BaseModel implements IWeather {
  public name: string;
  public description: string;

  constructor(data?: IWeather) {
    super(data);

    this.name = this.str(data?.name);
    this.description = this.str(data?.description);
  }
}
