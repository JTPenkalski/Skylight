import { BaseModel, IBaseModel } from "./index";

export interface IWeatherEventStatistics extends IBaseModel {
  damageCost: number;
  fatalities: number;
  efRating: string;
  pathDistance: number;
  funnelWidth: number;
  saffirSimpsonRating: string;
  lowestPressure: number;
  maxWindSpeed: number;
  richterMagnitude: number;
  mercalliIntensity: number;
  aftershocks: number;
  fault: string;
  relatedTsunami: boolean;
}

export class WeatherEventStatistics extends BaseModel implements IWeatherEventStatistics {
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
    id: number,
    damageCost: number,
    fatalities: number,
    efRating: string,
    pathDistance: number,
    funnelWidth: number,
    saffirSimpsonRating: string,
    lowestPressure: number,
    maxWindSpeed: number,
    richterMagnitude: number,
    mercalliIntensity: number,
    aftershocks: number,
    fault: string,
    relatedTsunami: boolean
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
