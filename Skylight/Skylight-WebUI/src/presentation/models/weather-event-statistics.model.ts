import { BaseModel } from './index';
import { IWeatherEventStatistics as IWeatherEventStatisticsWebModel } from 'web/web-models';

export interface IWeatherEventStatistics extends IWeatherEventStatisticsWebModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventStatistics extends BaseModel implements IWeatherEventStatistics {
  public damageCost?: number;
  public fatalities?: number;
  public efRating?: number;
  public pathDistance?: number;
  public funnelWidth?: number;
  public saffirSimpsonRating?: number;
  public lowestPressure?: number;
  public maxWindSpeed?: number;
  public richterMagnitude?: number;
  public mercalliIntensity?: number;
  public aftershocks?: number;
  public fault?: string;
  public relatedTsunami?: boolean;

  constructor(data?: IWeatherEventStatistics) {
    super(data);

    this.damageCost = this.num(data?.damageCost);
    this.fatalities = this.num(data?.fatalities);
    this.efRating = this.num(data?.efRating);
    this.pathDistance = this.num(data?.pathDistance);
    this.funnelWidth = this.num(data?.funnelWidth);
    this.saffirSimpsonRating = this.num(data?.saffirSimpsonRating);
    this.lowestPressure = this.num(data?.lowestPressure);
    this.maxWindSpeed = this.num(data?.maxWindSpeed);
    this.richterMagnitude = this.num(data?.richterMagnitude);
    this.mercalliIntensity = this.num(data?.mercalliIntensity);
    this.aftershocks = this.num(data?.aftershocks);
    this.fault = this.str(data?.fault);
    this.relatedTsunami = this.bool(data?.relatedTsunami);
  }
}
