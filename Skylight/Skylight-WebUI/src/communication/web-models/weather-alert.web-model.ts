import { IBaseWebModel, IWeatherEventAlertWebModel } from './index';

export interface IWeatherAlertWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
  readonly value: number;
  readonly thirdParty: boolean;
  readonly events: IWeatherEventAlertWebModel[];
}
