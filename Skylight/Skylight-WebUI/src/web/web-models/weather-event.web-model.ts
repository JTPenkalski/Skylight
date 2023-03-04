import { BaseWebModel, LocationWebModel, WeatherEventAlertWebModel, WeatherEventStatisticsWebModel, WeatherExperienceWebModel, WeatherWebModel } from './index';

export class WeatherEventWebModel extends BaseWebModel {
  public readonly name: string;
  public readonly description: string;
  public readonly weather: WeatherWebModel;
  public readonly startDate: Date;
  public readonly statistics: WeatherEventStatisticsWebModel;
  public readonly experience: WeatherExperienceWebModel;
  public readonly locations: LocationWebModel[];
  public readonly alerts: WeatherEventAlertWebModel[];
  public readonly endDate?: Date;

  constructor(
    id: number,
    name: string,
    description: string,
    weather: WeatherWebModel,
    startDate: Date,
    statistics: WeatherEventStatisticsWebModel,
    weatherExperience: WeatherExperienceWebModel,
    locations: LocationWebModel[],
    alerts: WeatherEventAlertWebModel[],
    endDate?: Date
  ) {
    super(id);
    this.name = name;
    this.description = description;
    this.weather = weather;
    this.startDate = startDate;
    this.statistics = statistics;
    this.experience = weatherExperience;
    this.locations = locations;
    this.alerts = alerts;
    this.endDate = endDate;
  }
}
