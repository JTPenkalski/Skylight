import { Modify } from 'core/types';
import { BaseModel, IBaseModel, ILocation, IWeather, IWeatherEventAlert, IWeatherEventStatistics, IWeatherExperience, Location, Weather, WeatherEventAlert, WeatherEventStatistics, WeatherExperience } from './index';
import { WeatherEvent as WeatherEventWebModel, IWeatherEvent as IWeatherEventWebModel } from 'web/models';

export interface IWeatherEvent extends Modify<IWeatherEventWebModel, {
  weather: IWeather,
  statistics: IWeatherEventStatistics,
  experience: IWeatherExperience,
  locations: ILocation[],
  alerts: IWeatherEventAlert[],
}>, IBaseModel {
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
  public description?: string | null;
  public endDate?: Date | null;

  constructor(data?: IWeatherEvent) {
    super(data);

    this.name = this.str(data?.name);
    this.weather = new Weather(data?.weather);
    this.startDate = this.date(data?.startDate);
    this.statistics = new WeatherEventStatistics(data?.statistics);
    this.experience = new WeatherExperience(data?.experience);
    this.locations = this.arr<Location>(data?.locations as Location[]);
    this.alerts = this.arr<WeatherEventAlert>(data?.alerts as WeatherEventAlert[]);
    this.description = data?.description;
    this.endDate = data?.endDate;
  }
}
