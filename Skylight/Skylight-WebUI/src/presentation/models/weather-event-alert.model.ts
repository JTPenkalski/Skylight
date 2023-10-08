import { Modify } from 'core/types';
import { BaseModel, IBaseModel, IWeatherAlert, IWeatherEventAlertModifier, WeatherAlert,  WeatherEventAlertModifier } from './index';
import { IWeatherEventAlert as IWeatherEventAlertWebModel } from 'web/models';

export interface IWeatherEventAlert extends Modify<IWeatherEventAlertWebModel, {
  alert: IWeatherAlert,
  modifiers: IWeatherEventAlertModifier[]
}>, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventAlert extends BaseModel implements IWeatherEventAlert {
  public alert: WeatherAlert;
  public issuanceTime: Date;
  public modifiers: WeatherEventAlertModifier[];

  constructor(data?: IWeatherEventAlert) {
    super(data);

    this.alert = new WeatherAlert(data?.alert);
    this.issuanceTime = this.date(data?.issuanceTime);
    this.modifiers = this.arr<WeatherEventAlertModifier>(data?.modifiers as WeatherEventAlertModifier[], [ new WeatherEventAlertModifier() ]);
  }
}
