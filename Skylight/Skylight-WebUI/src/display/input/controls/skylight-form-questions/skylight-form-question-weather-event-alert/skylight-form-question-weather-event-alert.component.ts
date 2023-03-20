import { Component, Inject } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';

import { WeatherAlertModifier } from 'core/models';
import { IWeatherEventAlertFormModel } from 'display/input/form-models';
import { ReadOnlyFormGroup } from 'display/input/types';
import { FormQuestionConfiguration, FORM_QUESTION_CONFIG } from 'presentation/injection';
import { WeatherAlertModifierFormMapper } from 'presentation/mappings';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-weather-event-alert[instance]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent extends SkylightFormQuestionComponent {
  public get weatherEventAlert(): FormGroup<IWeatherEventAlertFormModel> { return this.control as FormGroup<IWeatherEventAlertFormModel>; }
  public get modifiers(): FormArray<ReadOnlyFormGroup<WeatherAlertModifier>> { return this.control.get('modifiers') as FormArray<ReadOnlyFormGroup<WeatherAlertModifier>>; }

  constructor(
    @Inject(FORM_QUESTION_CONFIG) config: FormQuestionConfiguration,
    private readonly weatherAlertModifierMapper: WeatherAlertModifierFormMapper
  ) {
    super(config);
  }

  public addWeatherAlertModifier(): void {
    this.modifiers.push(this.weatherAlertModifierMapper.toDisplayModel(new WeatherAlertModifier()));
  }

  public removeWeatherAlertModifier(modifierIndex: number): void {
    this.modifiers.removeAt(modifierIndex);
  }
}
