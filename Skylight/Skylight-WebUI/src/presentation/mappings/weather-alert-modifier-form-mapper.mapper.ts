import { Injectable } from '@angular/core';
import { Validators } from '@angular/forms';

import { BaseFormMapper } from './index';
import { WeatherAlertModifier } from 'presentation/models';
import { ReadOnlyFormGroup } from 'display/input/types';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertModifierFormMapper extends BaseFormMapper<WeatherAlertModifier, ReadOnlyFormGroup<WeatherAlertModifier>> {
  public toPresentationModel(source: ReadOnlyFormGroup<WeatherAlertModifier>): WeatherAlertModifier {
    return source.controls.control.value;
  }

  public toDisplayModel(source: WeatherAlertModifier): ReadOnlyFormGroup<WeatherAlertModifier> {
    return this.formBuilder.nonNullable.group({ control: this.formBuilder.nonNullable.control(source, Validators.required) });
  }
}
