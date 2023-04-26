import { Component, Inject, Input } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { FormQuestionConfiguration, FORM_QUESTION_CONFIG } from 'presentation/injection';
import { IWeatherAlertModifier, WeatherAlertModifier } from 'presentation/models';
import { IWeatherEventAlert } from 'display/input/models';

/**
 * Form Field group for the Weather Event Alert model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-weather-event-alert[group]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent extends SkylightFormQuestionComponent {
  @Input() public group!: FormGroup<IWeatherEventAlert>;
  
  public get modifiers(): FormArray<FormControl<IWeatherAlertModifier>> { return this.group.controls.modifiers; }

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
