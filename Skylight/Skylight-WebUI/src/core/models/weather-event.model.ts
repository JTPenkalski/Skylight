import { BaseModel, Location, Weather, WeatherEventAlert, WeatherEventStatistics, WeatherExperience } from './index';

export class WeatherEvent extends BaseModel {
  public name: string;
  public description: string;
  public weather: Weather;
  public startDate: Date;
  public statistics: WeatherEventStatistics;
  public experience: WeatherExperience;
  public locations: Location[];
  public alerts: WeatherEventAlert[];
  public endDate?: Date;

  constructor(
    name: string = '',
    description: string = '',
    weather: Weather = new Weather(),
    startDate: Date = new Date(),
    statistics: WeatherEventStatistics = new WeatherEventStatistics(),
    experience: WeatherExperience = new WeatherExperience(),
    locations: Location[] = [ new Location() ],
    alerts: WeatherEventAlert[] = [ new WeatherEventAlert() ],
    endDate?: Date,
    id?: number
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.weather = weather;
    this.startDate = startDate;
    this.endDate = endDate;
    this.statistics = statistics;
    this.experience = experience;
    this.locations = locations;
    this.alerts = alerts;
  }
}
