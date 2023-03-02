import { IBaseWebModel, IWeatherAlertWebModel, IWeatherAlertModifierWebModel, IWeatherEventWebModel } from "./index";

export interface IWeatherEventAlertWebModel extends IBaseWebModel {
  readonly event?: IWeatherEventWebModel;
  readonly alert: IWeatherAlertWebModel;
  readonly issuanceTime: Date;
  readonly modifiers: IWeatherAlertModifierWebModel[];
}
