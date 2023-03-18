import { BaseWebModel, WeatherAlertWebModel, WeatherAlertModifierWebModel, WeatherEventWebModel } from './index';

export class WeatherEventAlertWebModel extends BaseWebModel {
  public readonly alert: WeatherAlertWebModel;
  public readonly issuanceTime: Date;
  public readonly modifiers: WeatherAlertModifierWebModel[];

  constructor(
    id: number,
    alert: WeatherAlertWebModel,
    issuanceTime: Date,
    modifiers: WeatherAlertModifierWebModel[],
  ) {
    super(id);
    this.alert = alert;
    this.issuanceTime = issuanceTime;
    this.modifiers = modifiers;
  }
}
