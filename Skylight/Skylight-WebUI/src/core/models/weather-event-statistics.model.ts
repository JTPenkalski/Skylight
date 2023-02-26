import { BaseModel } from './index';

export class WeatherEventStatistics extends BaseModel {
  public damageCost: number;
  public fatalities: number;
  public efRating: string;
  public pathDistance: number;
  public funnelWidth: number;
  public saffirSimpsonRating: string;
  public lowestPressure: number;
  public maxWindSpeed: number;
  public richterMagnitude: number;
  public mercalliIntensity: number;
  public aftershocks: number;
  public fault: string;
  public relatedTsunami: boolean;

  constructor(
    id: number = 0,
    damageCost: number = 0,
    fatalities: number = 0,
    efRating: string = '',
    pathDistance: number = 0,
    funnelWidth: number = 0,
    saffirSimpsonRating: string = '',
    lowestPressure: number = 0,
    maxWindSpeed: number = 0,
    richterMagnitude: number = 0,
    mercalliIntensity: number = 0,
    aftershocks: number = 0,
    fault: string = '',
    relatedTsunami: boolean = false
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
