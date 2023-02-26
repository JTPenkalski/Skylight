import { IBaseWebModel } from "./index";

export interface IWeatherEventStatisticsWebModel extends IBaseWebModel {
  readonly damageCost: number;
  readonly fatalities: number;
  readonly efRating: string;
  readonly pathDistance: number;
  readonly funnelWidth: number;
  readonly saffirSimpsonRating: string;
  readonly lowestPressure: number;
  readonly maxWindSpeed: number;
  readonly richterMagnitude: number;
  readonly mercalliIntensity: number;
  readonly aftershocks: number;
  readonly fault: string;
  readonly relatedTsunami: boolean;
}
