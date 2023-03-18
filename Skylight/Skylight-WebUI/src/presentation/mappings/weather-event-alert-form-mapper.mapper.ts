import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { BaseFormMapper, WeatherAlertFormMapper, WeatherAlertModifierFormMapper } from './index';
import { WeatherEventAlert } from 'core/models';
import { IWeatherEventAlertFormModel } from 'display/input/form-models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventAlertFormMapper extends BaseFormMapper<WeatherEventAlert, IWeatherEventAlertFormModel> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherAlertMapper: WeatherAlertFormMapper,
    protected readonly weatherAlertModifierMapper: WeatherAlertModifierFormMapper
  ) {
    super(formBuilder);
  }

  public toPresentationModel(source: IWeatherEventAlertFormModel): WeatherEventAlert {
    return new WeatherEventAlert(
      source.alert.value,
      source.issuanceTime.value,
      source.modifiers.controls.map(m => this.weatherAlertModifierMapper.toPresentationModel(m))
    );
  }

  public toDisplayModel(source: WeatherEventAlert): IWeatherEventAlertFormModel {
    return {
      alert: this.formBuilder.nonNullable.control(source.alert, Validators.required),
      issuanceTime: this.formBuilder.nonNullable.control(source.issuanceTime, Validators.required),
      modifiers: this.formBuilder.nonNullable.array(source.modifiers.map(m => this.weatherAlertModifierMapper.toDisplayModel(m)))
    };
  }
}
