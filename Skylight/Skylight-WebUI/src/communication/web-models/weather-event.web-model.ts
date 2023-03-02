import { IBaseWebModel, ILocationWebModel, IWeatherEventAlertWebModel, IWeatherEventStatisticsWebModel, IWeatherExperienceWebModel, IWeatherWebModel } from './index';

export interface IWeatherEventWebModel extends IBaseWebModel {
  readonly name: string;
  readonly description: string;
  readonly weather: IWeatherWebModel;
  readonly startDate: Date;
  readonly endDate?: Date;
  readonly weatherExperience: IWeatherExperienceWebModel;
  readonly locations: ILocationWebModel[];
  readonly alerts: IWeatherEventAlertWebModel[];
  readonly statistics: IWeatherEventStatisticsWebModel;
}
