import { BaseWebModel } from './index'

export class WeatherEventStatisticsWebModel extends BaseWebModel {
  public readonly damageCost?: number;
  public readonly fatalities?: number;
  public readonly efRating?: string;
  public readonly pathDistance?: number;
  public readonly funnelWidth?: number;
  public readonly saffirSimpsonRating?: string;
  public readonly lowestPressure?: number;
  public readonly maxWindSpeed?: number;
  public readonly richterMagnitude?: number;
  public readonly mercalliIntensity?: number;
  public readonly aftershocks?: number;
  public readonly fault?: string;
  public readonly relatedTsunami?: boolean;

  constructor(
    id: number,
    damageCost?: number,
    fatalities?: number,
    efRating?: string,
    pathDistance?: number,
    funnelWidth?: number,
    saffirSimpsonRating?: string,
    lowestPressure?: number,
    maxWindSpeed?: number,
    richterMagnitude?: number,
    mercalliIntensity?: number,
    aftershocks?: number,
    fault?: string,
    relatedTsunami?: boolean
  ) {
    super(id);
    this.damageCost = damageCost;
    this.fatalities = fatalities;
    this.efRating = efRating;
    this.pathDistance = pathDistance;
    this.funnelWidth = funnelWidth;
    this.saffirSimpsonRating = saffirSimpsonRating;
    this.lowestPressure = lowestPressure;
    this.maxWindSpeed = maxWindSpeed;
    this.richterMagnitude = richterMagnitude;
    this.mercalliIntensity = mercalliIntensity;
    this.aftershocks = aftershocks;
    this.fault = fault;
    this.relatedTsunami = relatedTsunami;
  }
}
