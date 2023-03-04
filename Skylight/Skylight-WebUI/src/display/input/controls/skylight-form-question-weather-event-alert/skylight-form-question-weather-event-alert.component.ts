import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { WeatherAlertModifier } from 'core/models';
import { IWeatherEventAlertFormModel } from 'display/input/form-models';
import { SkylightFormQuestionComponent } from '../skylight-form-question/skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-weather-event-alert[instance]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['../skylight-form-question/skylight-form-question.component.scss', './skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent extends SkylightFormQuestionComponent {
  public get weatherEventAlert(): FormArray<FormGroup<IWeatherEventAlertFormModel>> { return this.instance.control as FormArray<FormGroup<IWeatherEventAlertFormModel>>; }

  public getAlertModifiers(index: number): FormArray<FormControl<WeatherAlertModifier>> { return this.weatherEventAlert.at(index).get('modifiers') as FormArray<FormControl<WeatherAlertModifier>>; }
}
