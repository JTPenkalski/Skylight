import { Component } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';

import { WeatherAlertModifier } from 'core/models';
import { IWeatherEventAlertFormModel } from 'display/input/form-models';
import { FormArrayControl } from 'display/input/types';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-weather-event-alert[instance]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent extends SkylightFormQuestionComponent {
  public get weatherEventAlert(): FormArray<FormGroup<IWeatherEventAlertFormModel>> { return this.control as FormArray<FormGroup<IWeatherEventAlertFormModel>>; }

  public getAlertModifiers(index: number): FormArray<FormGroup<FormArrayControl<WeatherAlertModifier>>> { return this.weatherEventAlert.at(index).get('modifiers') as FormArray<FormGroup<FormArrayControl<WeatherAlertModifier>>>; }
}
