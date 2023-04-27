import { BaseModel, IBaseModel } from './index';
import { IWeatherEventStatistics as IWeatherEventStatisticsWebModel } from 'web/models';

export interface IWeatherEventStatistics extends IWeatherEventStatisticsWebModel, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventStatistics extends BaseModel implements IWeatherEventStatistics {
  public damageCost?: number | null;
  public fatalities?: number | null;
  public efRating?: number | null;
  public pathDistance?: number | null;
  public funnelWidth?: number | null;
  public saffirSimpsonRating?: number | null;
  public lowestPressure?: number | null;
  public maxWindSpeed?: number | null;
  public richterMagnitude?: number | null;
  public mercalliIntensity?: number | null;
  public aftershocks?: number | null;
  public fault?: string | null;
  public relatedTsunami?: boolean | null;

  constructor(data?: IWeatherEventStatistics) {
    super(data);

    this.damageCost = data?.damageCost;
    this.fatalities = data?.fatalities;
    this.efRating = data?.efRating;
    this.pathDistance = data?.pathDistance;
    this.funnelWidth = data?.funnelWidth;
    this.saffirSimpsonRating = data?.saffirSimpsonRating;
    this.lowestPressure = data?.lowestPressure;
    this.maxWindSpeed = data?.maxWindSpeed;
    this.richterMagnitude = data?.richterMagnitude;
    this.mercalliIntensity = data?.mercalliIntensity;
    this.aftershocks = data?.aftershocks;
    this.fault = data?.fault;
    this.relatedTsunami = data?.relatedTsunami;
  }
}
