import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';

import { BaseModel, IBaseModel } from './index';
import {
  WeatherEventAlert as WeatherEventAlertCoreModel, IWeatherEventAlert as IWeatherEventAlertCoreModel,
  IWeatherAlert as IWeatherAlertCoreModel,
  IWeatherAlertModifier as IWeatherAlertModifierCoreModel
} from 'presentation/models';

export interface IWeatherEventAlert extends IBaseModel {
  readonly alert: FormControl<IWeatherAlertCoreModel>;
  readonly issuanceTime: FormControl<Date>;
  readonly modifiers: FormArray<FormControl<IWeatherAlertModifierCoreModel>>;
}

export class WeatherEventAlert extends BaseModel implements IWeatherEventAlert {
  public readonly alert: FormControl<IWeatherAlertCoreModel>;
  public readonly issuanceTime: FormControl<Date>;
  public readonly modifiers: FormArray<FormControl<IWeatherAlertModifierCoreModel>>;

  constructor(formBuilder: FormBuilder, data?: IWeatherEventAlertCoreModel) {
    super(formBuilder);

    data ??= new WeatherEventAlertCoreModel();

    this.alert = formBuilder.nonNullable.control(data.alert, Validators.required),
    this.issuanceTime = formBuilder.nonNullable.control(data.issuanceTime, Validators.required),
    this.modifiers = formBuilder.nonNullable.array(data.modifiers.map(m => formBuilder.nonNullable.control(m, Validators.required)))
  }
}
