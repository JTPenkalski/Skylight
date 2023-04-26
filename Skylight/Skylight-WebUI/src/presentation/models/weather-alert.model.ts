import { BaseModel, IBaseModel } from './index';
import { IWeatherAlert as IWeatherAlertWebModel } from 'web/models';

export interface IWeatherAlert extends IWeatherAlertWebModel, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherAlert extends BaseModel implements IWeatherAlert {
  public name: string;
  public description: string;
  public value: number;
  public isThirdParty: boolean;

  constructor(data?: IWeatherAlert) {
    super(data);
    
    this.name = this.str(data?.name);
    this.description = this.str(data?.description);;
    this.value = this.num(data?.value);
    this.isThirdParty = this.bool(data?.isThirdParty);
  }
}
