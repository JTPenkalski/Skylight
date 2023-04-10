import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { IWeatherEventStatisticsFormModel } from 'display/input/form-models';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { ISelectOption } from '../types';

@Component({
  selector: 'skylight-form-question-weather-event-statistics',
  templateUrl: './skylight-form-question-weather-event-statistics.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-statistics.component.scss']
})
export class SkylightFormQuestionWeatherEventStatisticsComponent extends SkylightFormQuestionComponent {
  public get statistics(): FormGroup<IWeatherEventStatisticsFormModel> { return this.control as FormGroup<IWeatherEventStatisticsFormModel>; }

  public readonly efRatingOptions: ISelectOption[] = [
    { name: 'EF-1', value: 1 },
    { name: 'EF-2', value: 2 },
    { name: 'EF-3', value: 3 },
    { name: 'EF-4', value: 4 },
    { name: 'EF-5', value: 5 }
  ]

  public readonly saffirSimpsonRatingOptions: ISelectOption[] = [
    { name: 'Category 1', value: 1 },
    { name: 'Category 2', value: 2 },
    { name: 'Category 3', value: 3 },
    { name: 'Category 4', value: 4 },
    { name: 'Category 5', value: 5 }
  ]

  public readonly mercalliIntensityOptions: ISelectOption[] = [
    { name: 'I - Not Felt', value: 1 },
    { name: 'II - Weak', value: 2 },
    { name: 'III - Weak', value: 3 },
    { name: 'IV - Light', value: 4 },
    { name: 'V - Moderate', value: 5 },
    { name: 'VI - Strong', value: 6 },
    { name: 'VII - Very Strong', value: 7 },
    { name: 'VIII - Severe', value: 8 },
    { name: 'IX - Violent', value: 9 },
    { name: 'X - Extreme', value: 10 }
  ]

  ngOnInit() {
    console.log(this.statistics);
  }
}
