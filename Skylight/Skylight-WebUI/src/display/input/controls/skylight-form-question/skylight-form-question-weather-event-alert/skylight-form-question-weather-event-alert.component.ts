import { Component } from '@angular/core';
import { FormArray, FormControl } from '@angular/forms';

import { SkylightFormQuestionContainerComponent } from '../skylight-form-question-container.component';
import { IWeatherEventAlert } from 'display/input/models';
import { IWeatherAlertModifier, WeatherAlertModifier } from 'presentation/models';

/**
 * Form Field group for the Weather Event Alert model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-weather-event-alert[group]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent extends SkylightFormQuestionContainerComponent<IWeatherEventAlert> {  
  public get modifiers(): FormArray<FormControl<IWeatherAlertModifier>> { return this.group.controls.modifiers; }

  public addWeatherAlertModifier(): void {
    this.modifiers.push(new FormControl<IWeatherAlertModifier>(new WeatherAlertModifier(), { nonNullable: true }));
  }

  public removeWeatherAlertModifier(modifierIndex: number): void {
    this.modifiers.removeAt(modifierIndex);
  }
}
