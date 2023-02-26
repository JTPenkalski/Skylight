import { IBaseWebModel, IWeatherEventWebModel } from './index';

export interface IWeatherAlertWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
  readonly value: number;
  readonly thirdParty: boolean;
  readonly events: IWeatherEventWebModel[];
}
