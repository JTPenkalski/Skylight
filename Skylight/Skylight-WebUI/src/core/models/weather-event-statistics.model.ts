import { BaseModel } from './index';

export class WeatherEventStatistics extends BaseModel {
  public damageCost: number | null;
  public fatalities: number | null;
  public efRating: string | null;
  public pathDistance: number | null;
  public funnelWidth: number | null;
  public saffirSimpsonRating: string | null;
  public lowestPressure: number | null;
  public maxWindSpeed: number | null;
  public richterMagnitude: number | null;
  public mercalliIntensity: number | null;
  public aftershocks: number | null;
  public fault: string | null;
  public relatedTsunami: boolean | null;

  constructor(
    damageCost: number | null = null,
    fatalities: number | null = null,
    efRating: string | null = null,
    pathDistance: number | null = null,
    funnelWidth: number | null = null,
    saffirSimpsonRating: string | null = null,
    lowestPressure: number | null = null,
    maxWindSpeed: number | null = null,
    richterMagnitude: number | null = null,
    mercalliIntensity: number | null = null,
    aftershocks: number | null = null,
    fault: string | null = null,
    relatedTsunami: boolean | null = null,
    id?: number
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
