import { FormArray, FormControl } from '@angular/forms';

import { WeatherAlert, WeatherAlertModifier } from 'core/models';
import { IBaseFormModel } from './index';

export interface IWeatherEventAlertFormModel extends IBaseFormModel {
  readonly alert: FormControl<WeatherAlert>;
  readonly issuanceTime: FormControl<Date>;
  readonly modifiers: FormArray<FormControl<WeatherAlertModifier>>;
}
