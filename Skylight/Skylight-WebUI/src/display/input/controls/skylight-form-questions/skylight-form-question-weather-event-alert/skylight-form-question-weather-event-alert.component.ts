import { Component, Inject } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { FormQuestionConfiguration, FORM_QUESTION_CONFIG } from 'presentation/injection';
import { IWeatherAlertModifier, WeatherAlertModifier } from 'presentation/models';
import { IWeatherEventAlert } from 'display/input/form-models';
import { ReadOnlyFormGroup } from 'display/input/types';

@Component({
  selector: 'skylight-form-question-weather-event-alert[instance]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent extends SkylightFormQuestionComponent {
  public get weatherEventAlert(): FormGroup<IWeatherEventAlert> { return this.control as FormGroup<IWeatherEventAlert>; }
  public get modifiers(): FormArray<FormControl<IWeatherAlertModifier>> { return this.weatherEventAlert.controls.modifiers; }

  constructor(@Inject(FORM_QUESTION_CONFIG) config: FormQuestionConfiguration) {
    super(config);
  }

  public addWeatherAlertModifier(): void {
    this.modifiers.push(new FormControl<IWeatherAlertModifier>(new WeatherAlertModifier(), { nonNullable: true }));
  }

  public removeWeatherAlertModifier(modifierIndex: number): void {
    this.modifiers.removeAt(modifierIndex);
  }
}
