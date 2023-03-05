import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { WeatherAlert, WeatherAlertModifier } from 'core/models';
import { FormArrayControl } from '../types';
import { IBaseFormModel } from './index';

export interface IWeatherEventAlertFormModel extends IBaseFormModel {
  readonly alert: FormControl<WeatherAlert>;
  readonly issuanceTime: FormControl<Date>;
  readonly modifiers: FormArray<FormGroup<FormArrayControl<WeatherAlertModifier>>>;
}
