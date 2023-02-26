import { IBaseWebModel } from "./index";

export interface IWeatherEventObservationMethodWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
}
