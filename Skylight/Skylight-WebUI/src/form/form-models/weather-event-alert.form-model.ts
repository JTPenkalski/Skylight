import { FormArray, FormControl } from '@angular/forms';

import { WeatherAlert, WeatherAlertModifier } from 'core/models';
import { IBaseFormModel, IWeatherEventFormModel } from "./index";

export interface IWeatherEventAlertFormModel extends IBaseFormModel {
  readonly alert: FormControl<WeatherAlert>;
  readonly modifiers: FormArray<FormControl<WeatherAlertModifier>>;
}
