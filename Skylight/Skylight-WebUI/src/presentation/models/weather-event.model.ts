import { Modify } from 'core/types';
import { BaseModel, Location, Weather, WeatherEventAlert, WeatherEventStatistics, WeatherExperience } from './index';
import { IWeatherEvent as IWeatherEventWebModel } from 'web/web-models';

export interface IWeatherEvent extends Modify<IWeatherEventWebModel, {
  weather: Weather,
  statistics: WeatherEventStatistics,
  experience: WeatherExperience,
  locations: Location[],
  alerts: WeatherEventAlert[],
}> {
  // Add any Presentation Layer data fields here...
}

export class WeatherEvent extends BaseModel implements IWeatherEvent {
  public name: string;
  public weather: Weather;
  public startDate: Date;
  public statistics: WeatherEventStatistics;
  public experience: WeatherExperience;
  public locations: Location[];
  public alerts: WeatherEventAlert[];
  public description?: string;
  public endDate?: Date;

  constructor(data?: IWeatherEvent) {
    super(data);

    this.name = this.str(data?.name);
    this.weather = this.obj(data?.weather, new Weather());
    this.startDate = this.date(data?.startDate);
    this.statistics = this.obj(data?.statistics, new WeatherEventStatistics());
    this.experience = this.obj(data?.experience, new WeatherExperience());
    this.locations = this.arr(data?.locations);
    this.alerts = this.arr(data?.alerts);
    this.description = data?.description;
    this.endDate = data?.endDate;
  }
}
