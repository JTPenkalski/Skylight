import { Modify } from 'core/types';
import { BaseModel, IBaseModel, IWeatherAlert, IWeatherAlertModifier, WeatherAlert, WeatherAlertModifier } from './index';
import { IWeatherEventAlert as IWeatherEventAlertWebModel } from 'web/web-models';

export interface IWeatherEventAlert extends Modify<IWeatherEventAlertWebModel, {
  alert: IWeatherAlert,
  modifiers: IWeatherAlertModifier[]
}>, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventAlert extends BaseModel implements IWeatherEventAlert {
  public alert: WeatherAlert;
  public issuanceTime: Date;
  public modifiers: WeatherAlertModifier[];

  constructor(data?: IWeatherEventAlert) {
    super(data);
    
    this.alert = new WeatherAlert(data?.alert);
    this.issuanceTime = this.date(data?.issuanceTime);
    this.modifiers = this.arr<WeatherAlertModifier>(data?.modifiers as WeatherAlertModifier[], [ new WeatherAlertModifier() ]);
  }
}
