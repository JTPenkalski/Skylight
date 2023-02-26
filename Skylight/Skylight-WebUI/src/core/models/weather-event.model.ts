import { BaseModel, Location, Weather, WeatherEventAlert, WeatherEventStatistics, WeatherExperience } from './index';

export class WeatherEvent extends BaseModel {
  public name: string;
  public description: string;
  public weather: Weather;
  public startDate: Date;
  public endDate: Date | null;
  public statistics: WeatherEventStatistics;
  public experience: WeatherExperience;
  public locations: Location[];
  public alerts: WeatherEventAlert[];

  constructor(
    id: number,
    name: string,
    description: string,
    weather: Weather,
    startDate: Date,
    endDate: Date | null,
    statistics: WeatherEventStatistics,
    experience: WeatherExperience,
    locations: Location[],
    alerts: WeatherEventAlert[]
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
