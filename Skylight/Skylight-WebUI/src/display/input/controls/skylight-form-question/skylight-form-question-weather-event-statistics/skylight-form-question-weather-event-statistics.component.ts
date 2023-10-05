import { Component } from '@angular/core';

import { SkylightFormQuestionContainerComponent } from '../skylight-form-question-container.component';
import { IWeatherEventStatistics } from 'display/input/models';
import { ISelectOption } from '../types';
import { WeatherEventStatisticsFormGuide } from 'web/models';

/**
 * Form Field group for the Weather Event Statistics model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-weather-event-statistics[group]',
  templateUrl: './skylight-form-question-weather-event-statistics.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-statistics.component.scss']
})
export class SkylightFormQuestionWeatherEventStatisticsComponent extends SkylightFormQuestionContainerComponent<IWeatherEventStatistics, WeatherEventStatisticsFormGuide> {
  public readonly efRatingOptions: ISelectOption[] = [
    { name: 'EF-U', value: -1 },
    { name: 'EF-0', value: 0 },
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

  public get showTornadoSection(): boolean {
    return ![
      this.guide?.efRating,
      this.guide?.funnelWidth,
      this.guide?.pathDistance
    ].every(x => x?.hidden);
  }

  public get showHurricaneSection(): boolean {
    return ![
      this.guide?.saffirSimpsonRating,
      this.guide?.lowestPressure,
      this.guide?.maxWindSpeed
    ].every(x => x?.hidden);
  }

  public get showEarthquakeSection(): boolean {
    return ![
      this.guide?.richterMagnitude,
      this.guide?.mercalliIntensity,
      this.guide?.aftershocks,
      this.guide?.fault,
      this.guide?.relatedTsunami
    ].every(x => x?.hidden);
  }
}
