import { Component, Input } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { ISkylightFormQuestionContainer } from '../types';
import { IWeatherAlertModifier, WeatherAlertModifier } from 'presentation/models';
import { IWeatherEventAlert } from 'display/input/models';

/**
 * Form Field group for the Weather Event Alert model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-weather-event-alert[group]',
  templateUrl: './skylight-form-question-weather-event-alert.component.html',
  styleUrls: ['./skylight-form-question-weather-event-alert.component.scss']
})
export class SkylightFormQuestionWeatherEventAlertComponent implements ISkylightFormQuestionContainer {
  @Input() public label: string = '';
  @Input() public group!: FormGroup<IWeatherEventAlert>;
  
  public get modifiers(): FormArray<FormControl<IWeatherAlertModifier>> { return this.group.controls.modifiers; }

  public addWeatherAlertModifier(): void {
    this.modifiers.push(new FormControl<IWeatherAlertModifier>(new WeatherAlertModifier(), { nonNullable: true }));
  }

  public removeWeatherAlertModifier(modifierIndex: number): void {
    this.modifiers.removeAt(modifierIndex);
  }
}
