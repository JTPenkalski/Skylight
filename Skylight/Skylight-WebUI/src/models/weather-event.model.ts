import { BaseModel, IBaseModel, Location, Weather, WeatherEventAlert, WeatherEventStatistics, WeatherExperience } from "./index";

export interface IWeatherEvent extends IBaseModel {
  name: string;
  description: string;
  weather: Weather;
  startDate: Date;
  endDate: Date;
  statistics: WeatherEventStatistics;
  experience: WeatherExperience;
  locations: Location[];
  alerts: WeatherEventAlert[];
}

export class WeatherEvent extends BaseModel implements IWeatherEvent {
  public name: string;
  public description: string;
  public weather: Weather;
  public startDate: Date;
  public endDate: Date;
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
    endDate: Date,
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
