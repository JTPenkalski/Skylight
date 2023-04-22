import { Modify } from 'core/types';
import { BaseModel, WeatherAlert, WeatherAlertModifier } from './index';
import { IWeatherEventAlert as IWeatherEventAlertWebModel } from 'web/web-models';

export interface IWeatherEventAlert extends Modify<IWeatherEventAlertWebModel, {
  alert: WeatherAlert,
  modifiers: WeatherAlertModifier[]
}> {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventAlert extends BaseModel implements IWeatherEventAlert {
  public alert: WeatherAlert;
  public issuanceTime: Date;
  public modifiers: WeatherAlertModifier[];

  constructor(data?: IWeatherEventAlert) {
    super(data);
    let x = data?.issuanceTime;
    this.alert = this.obj(data?.alert, new WeatherAlert());
    this.issuanceTime = this.date(data?.issuanceTime);
    this.modifiers = this.arr(data?.modifiers, [ new WeatherAlertModifier() ]);
  }
}
