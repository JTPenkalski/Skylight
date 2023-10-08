import { Modify } from 'core/types';
import { BaseModel, IBaseModel, ILocation, Location } from './index';
import { IWeatherEventLocation as IWeatherEventLocationWebModel } from 'web/models';

export interface IWeatherEventLocation extends Modify<IWeatherEventLocationWebModel, {
  location: ILocation,
}>, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherEventLocation extends BaseModel implements IWeatherEventLocation {
  public startTime: Date;
  public endTime: Date;
  public location: ILocation;

  constructor(data?: IWeatherEventLocation) {
    super(data);
    
    this.startTime = this.date(data?.startTime);
    this.endTime = this.date(data?.endTime);
    this.location = new Location(data?.location);
  }
}