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

    this.damageCost = this.nullable(data?.damageCost);
    this.fatalities = this.nullable(data?.fatalities);
    this.efRating = this.nullable(data?.efRating);
    this.pathDistance = this.nullable(data?.pathDistance);
    this.funnelWidth = this.nullable(data?.funnelWidth);
    this.saffirSimpsonRating = this.nullable(data?.saffirSimpsonRating);
    this.lowestPressure = this.nullable(data?.lowestPressure);
    this.maxWindSpeed = this.nullable(data?.maxWindSpeed);
    this.richterMagnitude = this.nullable(data?.richterMagnitude);
    this.mercalliIntensity = this.nullable(data?.mercalliIntensity);
    this.aftershocks = this.nullable(data?.aftershocks);
    this.fault = this.nullable(data?.fault);
    this.relatedTsunami = this.nullable(data?.relatedTsunami);
  }
}
