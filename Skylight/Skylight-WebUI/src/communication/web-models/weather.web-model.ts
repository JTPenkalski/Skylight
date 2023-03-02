import { IBaseWebModel, IWeatherEventWebModel } from "./index";

export interface IWeatherWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
  readonly events?: IWeatherEventWebModel[];
}
