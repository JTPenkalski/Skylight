import { FormArray, FormControl } from '@angular/forms';

import { Weather, WeatherExperience } from 'core/models';
import { ILocationFormModel, IWeatherEventAlertFormModel, IWeatherEventStatisticsFormModel, IWeatherExperienceFormModel } from './index';

export interface IWeatherEventFormModel {
  readonly name: FormControl<string>;
  readonly description: FormControl<string>;
  readonly weather: FormControl<Weather>;
  readonly startDate: FormControl<Date>;
  readonly endDate: FormControl<Date | null>;
  readonly weatherExperience: FormControl<WeatherExperience>;
  readonly locations: FormArray<FormControl<ILocationFormModel>>;
  readonly alerts: FormArray<FormControl<IWeatherEventAlertFormModel>>;
  readonly statistics: FormControl<IWeatherEventStatisticsFormModel>;
}
