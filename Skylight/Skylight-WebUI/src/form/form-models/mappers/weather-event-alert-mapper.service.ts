import { Injectable } from '@angular/core';
import { Validators } from '@angular/forms';

import { BaseMapper } from './index';
import { WeatherAlert, WeatherEventAlert } from 'core/models';
import { IWeatherEventAlertFormModel } from 'form/form-models';

@Injectable()
export class WeatherEventAlertMapper extends BaseMapper<WeatherEventAlert, IWeatherEventAlertFormModel> {
  public toPresentationModel(formModel: IWeatherEventAlertFormModel): WeatherEventAlert {
    return new WeatherEventAlert(
      0,
      null,
      formModel.alert.value,
      formModel.modifiers.value
    );
  }

  public toFormModel(presentationModel?: WeatherEventAlert): IWeatherEventAlertFormModel {
    return {
      alert: this.formBuilder.nonNullable.control(presentationModel?.alert ?? new WeatherAlert(), Validators.required),
      modifiers: this.formBuilder.nonNullable.array(presentationModel?.modifiers.map(m => this.formBuilder.nonNullable.control(m, Validators.required)) ?? [])
    };
  }
}
