import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { Weather, WeatherExperience } from 'core/models';
import { ILocationFormModel, IWeatherEventAlertFormModel, IWeatherEventStatisticsFormModel } from './index';

export interface IWeatherEventFormModel {
  readonly name: FormControl<string>;
  readonly description: FormControl<string>;
  readonly weather: FormControl<Weather>;
  readonly startDate: FormControl<Date>;
  readonly endDate: FormControl<Date | null>;
  readonly weatherExperience: FormControl<WeatherExperience>;
  readonly locations: FormArray<FormGroup<ILocationFormModel>>;
  readonly alerts: FormArray<FormGroup<IWeatherEventAlertFormModel>>;
  readonly statistics: FormGroup<IWeatherEventStatisticsFormModel>;
}
